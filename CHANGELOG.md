# ChangeLog

## 0.2.0 (09/14/2026)

### Breaking changes

#### Renamed operations

| Client | Previous | Current |
| --- | --- | --- |
| `LogisticsClient` | `CreateShipmentFromQuoteAsync` | `CreateFromShippingQuoteAsync` |
| `LogisticsClient` | `DownloadShipmentLabelAsync` | `DownloadLabelFileAsync` |

#### Removed operations

- `FulfillmentClient.GetPaymentDisputeActivityAsync(string, string?, RequestOptions?, CancellationToken)`

#### Changed signatures

`FulfillmentClient`:

| Operation | Previous parameters | Current parameters |
| --- | --- | --- |
| `GetOrderAsync` | `(string, string?, RequestOptions?, CancellationToken)` | `(string, string?, string?, RequestOptions?, CancellationToken)` |
| `GetOrdersAsync` | `(string?, int?, int?, string?, string?, string?, RequestOptions?, CancellationToken)` | `(string?, string?, string?, string?, string?, string?, RequestOptions?, CancellationToken)` |
| `GetPaymentDisputeSummariesAsync` | `(string?, int?, int?, string?, string?, string?, string?, string?, RequestOptions?, CancellationToken)` | `(string?, string?, string?, string?, string?, string?, string?, string?, RequestOptions?, CancellationToken)` |
| `UploadEvidenceFileAsync` | `(string, string?, RequestOptions?, CancellationToken)` | `(string, Stream, string, string?, RequestOptions?, CancellationToken)` |

`LogisticsClient`:

| Operation | Previous parameters | Current parameters |
| --- | --- | --- |
| `CreateShippingQuoteAsync` | `(ShippingQuoteRequest, string?, RequestOptions?, CancellationToken)` | `(string, ShippingQuoteRequest, string?, RequestOptions?, CancellationToken)` |
| `CreateFromShippingQuoteAsync` | `(CreateShipmentFromQuoteRequest, string?, RequestOptions?, CancellationToken)` | `(string, CreateShipmentFromQuoteRequest, string?, RequestOptions?, CancellationToken)` |

### Added

- `FulfillmentClient.GetActivitiesAsync(string, string?, RequestOptions?, CancellationToken)`
- Client `PostOrderApiClient`
- Member `OrderManagementClient.PostOrderApi`
- Member `OrderManagementConfiguration.PostOrderApiBaseUrl`
