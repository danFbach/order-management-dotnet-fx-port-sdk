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


using Microsoft.Kiota.Abstractions;
using EBay.OrderManagement.Configuration;
using EBay.OrderManagement.Exceptions;
using EBay.OrderManagement.Generated.Logistics;
using EBay.OrderManagement.Generated.Logistics.Models;
using System.Net;

namespace EBay.OrderManagement.Clients.Rest;

public sealed class LogisticsClient
{
    private readonly LogisticsApiClient _kiota;
    private readonly OrderManagementConfiguration _config;
    private readonly ITokenContext _tokenContext;

    internal LogisticsClient(LogisticsApiClient kiota, OrderManagementConfiguration config, ITokenContext tokenContext)
        => (_kiota, _config, _tokenContext) = (kiota, config, tokenContext);

    private void ApplyHeaders(RequestHeaders headers, RequestOptions? callOptions)
    {
        foreach (var (k, v) in _config.DefaultRequestOptions.Headers)
            headers.TryAdd(k, v);
        if (callOptions is null) return;
        foreach (var (k, v) in callOptions.Headers)
            headers[k] = new[] { v };
    }

    // ── Shipping Quotes ───────────────────────────────────────────────────────

    public async Task<ShippingQuote?> GetShippingQuoteAsync(
        string shippingQuoteId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
    {
        try
        {
            return await _tokenContext.RunAsync(accessToken,
                () => _kiota.Shipping_quote[shippingQuoteId].GetAsync(
                    cfg => ApplyHeaders(cfg.Headers, requestOptions), ct));
        }
        catch (ApiException ex) when (ex.ResponseStatusCode == (int)HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex);
        }
    }

    public async Task<ShippingQuote?> CreateShippingQuoteAsync(
        ShippingQuoteRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
    {
        try
        {
            return await _tokenContext.RunAsync(accessToken,
                () => _kiota.Shipping_quote.PostAsync(body,
                    cfg => ApplyHeaders(cfg.Headers, requestOptions), ct));
        }
        catch (ApiException ex) when (ex.ResponseStatusCode == (int)HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex);
        }
    }

    // ── Shipments ─────────────────────────────────────────────────────────────

    public async Task<Shipment?> GetShipmentAsync(
        string shipmentId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
    {
        try
        {
            return await _tokenContext.RunAsync(accessToken,
                () => _kiota.Shipment[shipmentId].GetAsync(
                    cfg => ApplyHeaders(cfg.Headers, requestOptions), ct));
        }
        catch (ApiException ex) when (ex.ResponseStatusCode == (int)HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex);
        }
    }

    public async Task<Shipment?> CreateShipmentFromQuoteAsync(
        CreateShipmentFromQuoteRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
    {
        try
        {
            return await _tokenContext.RunAsync(accessToken,
                () => _kiota.Shipment.Create_from_shipping_quote.PostAsync(body,
                    cfg => ApplyHeaders(cfg.Headers, requestOptions), ct));
        }
        catch (ApiException ex) when (ex.ResponseStatusCode == (int)HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex);
        }
    }

    public async Task<Shipment?> CancelShipmentAsync(
        string shipmentId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
    {
        try
        {
            return await _tokenContext.RunAsync(accessToken,
                () => _kiota.Shipment[shipmentId].Cancel.PostAsync(
                    cfg => ApplyHeaders(cfg.Headers, requestOptions), ct));
        }
        catch (ApiException ex) when (ex.ResponseStatusCode == (int)HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex);
        }
    }

    public async Task<Stream?> DownloadShipmentLabelAsync(
        string shipmentId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
    {
        try
        {
            return await _tokenContext.RunAsync(accessToken,
                () => _kiota.Shipment[shipmentId].Download_label_file.GetAsync(
                    cfg => ApplyHeaders(cfg.Headers, requestOptions), ct));
        }
        catch (ApiException ex) when (ex.ResponseStatusCode == (int)HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedException(ex);
        }
    }
}
