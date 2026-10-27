using System.Net;
using System.Net.Http;

namespace EBay.OrderManagement.Clients.GraphQL;

/// <summary>
/// <see cref="HttpRequestException"/> that carries the HTTP status code, which
/// <see cref="HttpRequestException"/> does not expose on .NET Framework.
/// </summary>
internal sealed class GraphQLHttpException(HttpStatusCode statusCode, string message) : HttpRequestException(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}
