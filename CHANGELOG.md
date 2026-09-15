# ChangeLog

## 0.2.0 (09/14/2026)

### Breaking changes

#### Renamed operations

| Client | Previous | Current |
| --- | --- | --- |
| `LogisticsClient` | `CreateShipmentFromQuoteAsync` | `CreateFromShippingQuoteAsync` |
| `LogisticsClient` | `DownloadShipmentLabelAsync` | `DownloadLabelFileAsync` |

#### Removed operations

- `FulfillmentClient.GetPaymentDisputeActivityAsync(string paymentDisputeId, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)`

#### Changed signatures

`FulfillmentClient`:

| Operation | Previous parameters | Current parameters |
| --- | --- | --- |
| `GetOrderAsync` | `(string orderId, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` | `(string orderId, string? fieldGroups, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` |
| `GetOrdersAsync` | `(string? filter, int? limit, int? offset, string? fieldGroups, string? orderIds, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` | `(string? fieldGroups, string? filter, string? limit, string? offset, string? orderIds, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` |
| `GetPaymentDisputeSummariesAsync` | `(string? buyerUsername, int? limit, int? offset, string? openDateFrom, string? openDateTo, string? orderId, string? paymentDisputeStatus, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` | `(string? orderId, string? buyerUsername, string? openDateFrom, string? openDateTo, string? paymentDisputeStatus, string? limit, string? offset, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` |
| `UploadEvidenceFileAsync` | `(string paymentDisputeId, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` | `(string paymentDisputeId, Stream fileContent, string fileName, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` |

`LogisticsClient`:

| Operation | Previous parameters | Current parameters |
| --- | --- | --- |
| `CreateShippingQuoteAsync` | `(ShippingQuoteRequest body, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` | `(string xEBAYCMARKETPLACEID, ShippingQuoteRequest body, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` |
| `CreateFromShippingQuoteAsync` | `(CreateShipmentFromQuoteRequest body, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` | `(string xEBAYCMARKETPLACEID, CreateShipmentFromQuoteRequest body, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)` |

### Added

- `FulfillmentClient.GetActivitiesAsync(string paymentDisputeId, string? accessToken, RequestOptions? requestOptions, CancellationToken ct)`
- Client `PostOrderApiClient`
- Member `OrderManagementClient.PostOrderApi`
- Member `OrderManagementConfiguration.PostOrderApiBaseUrl`
