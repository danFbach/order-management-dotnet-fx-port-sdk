// Copyright 2026 eBay Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


using EBay.OrderManagement.Clients.GraphQL;
using EBay.OrderManagement.Clients.Rest;
using EBay.OrderManagement.Configuration;
using EBay.OrderManagement.Generated.Fulfillment;
using EBay.OrderManagement.Generated.GraphQL;
using EBay.OrderManagement.Generated.Logistics;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace EBay.OrderManagement;

public sealed class OrderManagementClient : IDisposable
{
    internal const string FulfillmentClientName = "OrderManagementFulfillmentClient";
    internal const string LogisticsClientName = "OrderManagementLogisticsClient";

    private readonly HttpClient _fulfillmentHttpClient;
    private readonly HttpClient _logisticsHttpClient;
    private readonly bool _ownsHttpClients;

    public FulfillmentClient Fulfillment { get; }
    public LogisticsClient Logistics { get; }
    public OrderGraphQLClient GraphQL { get; }

    /// <summary>
    /// Standalone constructor for use outside DI (tests, scripts).
    /// Typed GraphQL operations are not available in this mode; use GraphQL.ExecuteRawUnsafeAsync.
    /// </summary>
    public OrderManagementClient(OrderManagementConfiguration config)
        : this(
            config,
            BuildStandaloneHttpClient(config),
            BuildStandaloneHttpClient(config),
            null!,
            new AsyncLocalTokenContext())
    {
        _ownsHttpClients = true;
    }

    /// <summary>
    /// DI constructor: SS-generated GraphQL client and ITokenContext injected by the container.
    /// </summary>
    internal OrderManagementClient(
        OrderManagementConfiguration config,
        HttpClient fulfillmentHttpClient,
        HttpClient logisticsHttpClient,
        IOrderManagementGraphQLClient ssGqlClient,
        ITokenContext tokenContext)
    {
        _fulfillmentHttpClient = fulfillmentHttpClient;
        _logisticsHttpClient = logisticsHttpClient;
        _ownsHttpClients = false;

        var auth = new BaseBearerTokenAuthenticationProvider(new KiotaAuthProvider(config, tokenContext));

        var fulfillmentAdapter = new HttpClientRequestAdapter(
            auth,
            httpClient: BuildKiotaClient(config.FulfillmentBaseUrl, fulfillmentHttpClient))
        {
            BaseUrl = config.FulfillmentBaseUrl
        };

        var logisticsAdapter = new HttpClientRequestAdapter(
            auth,
            httpClient: BuildKiotaClient(config.LogisticsBaseUrl, logisticsHttpClient))
        {
            BaseUrl = config.LogisticsBaseUrl
        };

        Fulfillment = new FulfillmentClient(new FulfillmentApiClient(fulfillmentAdapter), config, tokenContext);
        Logistics = new LogisticsClient(new LogisticsApiClient(logisticsAdapter), config, tokenContext);

        // For GraphQL dynamic client, use the fulfillment client (GraphQL has its own named client via StrawberryShake)
        GraphQL = new OrderGraphQLClient(ssGqlClient, new DynamicGraphQLClient(_fulfillmentHttpClient, config, tokenContext), tokenContext);
    }

    private static HttpClient BuildKiotaClient(string baseUrl, HttpClient httpClient)
    {
        httpClient.BaseAddress = new Uri(baseUrl);
        return httpClient;
    }

    private static HttpClient BuildStandaloneHttpClient(OrderManagementConfiguration config)
    {
        var handler = new DiagnosticLoggingHandler(config)
        {
            InnerHandler = new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(2) }
        };
        return new HttpClient(handler) { Timeout = config.HttpTimeout };
    }

    public void Dispose()
    {
        if (_ownsHttpClients)
        {
            _fulfillmentHttpClient.Dispose();
            _logisticsHttpClient.Dispose();
        }
    }
}
