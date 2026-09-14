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

using EBay.OrderManagement.Configuration;
using EBay.OrderManagement.Generated.PostOrderApi.Models;
using EBay.OrderManagement.Generated.PostOrderApi;
using Microsoft.Kiota.Abstractions;
using System.IO;

namespace EBay.OrderManagement.Clients.Rest;

public sealed class PostOrderApiClient
{
    private readonly PostOrderApiApiClient _kiota;
    private readonly OrderManagementConfiguration _config;
    private readonly ITokenContext _tokenContext;
    private readonly IRequestAdapter _adapter;

    internal PostOrderApiClient(PostOrderApiApiClient kiota, OrderManagementConfiguration config, ITokenContext tokenContext, IRequestAdapter adapter)
    {
        _kiota = kiota;
        _config = config;
        _tokenContext = tokenContext;
        _adapter = adapter;
    }

    /// <summary>
    /// Check Cancellation Eligibility
    /// </summary>
    public Task CheckCancellationEligibilityAsync(
        Stream body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Cancellation.Check_eligibility.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Get Cancellation
    /// </summary>
    public Task GetCancellationAsync(
        string cancelId,
        string? fieldgroups = null,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Cancellation[cancelId].GetAsync(cfg =>
        {
            if (fieldgroups is not null)
            {
                cfg.QueryParameters.Fieldgroups = fieldgroups;
            }
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Create Cancellation Request
    /// </summary>
    public Task CreateCancellationRequestAsync(
        Stream body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Cancellation.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Confirm Cancellation Refund
    /// </summary>
    public Task ConfirmAsync(
        string cancelId,
        Stream body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Cancellation[cancelId].Confirm.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Search Cancellations
    /// </summary>
    public Task SearchCancellationsAsync(
        string? cancelId = null,
        string? creationDateRangeFrom = null,
        string? creationDateRangeTo = null,
        string? itemId = null,
        string? legacyOrderId = null,
        string? limit = null,
        string? offset = null,
        string? role = null,
        string? sort = null,
        string? transactionId = null,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Cancellation.Search.GetAsync(cfg =>
        {
            if (cancelId is not null)
            {
                cfg.QueryParameters.CancelId = cancelId;
            }
            if (creationDateRangeFrom is not null)
            {
                cfg.QueryParameters.CreationDateRangeFrom = creationDateRangeFrom;
            }
            if (creationDateRangeTo is not null)
            {
                cfg.QueryParameters.CreationDateRangeTo = creationDateRangeTo;
            }
            if (itemId is not null)
            {
                cfg.QueryParameters.ItemId = itemId;
            }
            if (legacyOrderId is not null)
            {
                cfg.QueryParameters.LegacyOrderId = legacyOrderId;
            }
            if (limit is not null)
            {
                cfg.QueryParameters.Limit = limit;
            }
            if (offset is not null)
            {
                cfg.QueryParameters.Offset = offset;
            }
            if (role is not null)
            {
                cfg.QueryParameters.Role = role;
            }
            if (sort is not null)
            {
                cfg.QueryParameters.Sort = sort;
            }
            if (transactionId is not null)
            {
                cfg.QueryParameters.TransactionId = transactionId;
            }
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Approve Cancellation
    /// </summary>
    public Task ApproveCancellationAsync(
        string cancelId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Cancellation[cancelId].Approve.PostAsync(cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Reject Cancellation
    /// </summary>
    public Task RejectCancellationAsync(
        string cancelId,
        Stream body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Cancellation[cancelId].Reject.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Appeal Case Decision
    /// </summary>
    public Task AppealCaseDecisionAsync(
        string caseId,
        AppealRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Casemanagement[caseId].Appeal.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Get Case
    /// </summary>
    public Task<CaseDetailsResponse?> GetCaseAsync(
        string caseId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Casemanagement[caseId].GetAsync(cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Issue Case Refund
    /// </summary>
    public Task<VoluntaryRefundResponse?> IssueCaseRefundAsync(
        string caseId,
        CaseVoluntaryRefundRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Casemanagement[caseId].Issue_refund.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Provides Return Address
    /// </summary>
    public Task ProvideCaseReturnAddressAsync(
        string caseId,
        ReturnAddressRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Casemanagement[caseId].Provide_return_address.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Close Case
    /// </summary>
    public Task CloseCaseAsync(
        string caseId,
        BuyerCloseCaseRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Casemanagement[caseId].Close.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Provide Case Shipment Info
    /// </summary>
    public Task ProvideCaseShipmentInfoAsync(
        string caseId,
        ProvideShipmentInfoRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Casemanagement[caseId].Provide_shipment_info.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Search Cases
    /// </summary>
    public Task<CaseSearchResponse?> SearchCasesAsync(
        string? caseCreationDateRangeFrom = null,
        string? caseCreationDateRangeTo = null,
        string? caseStatusFilter = null,
        string? fieldgroups = null,
        string? itemId = null,
        string? limit = null,
        string? offset = null,
        string? orderId = null,
        string? returnId = null,
        string? sort = null,
        string? transactionId = null,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Casemanagement.Search.GetAsync(cfg =>
        {
            if (caseCreationDateRangeFrom is not null)
            {
                cfg.QueryParameters.CaseCreationDateRangeFrom = caseCreationDateRangeFrom;
            }
            if (caseCreationDateRangeTo is not null)
            {
                cfg.QueryParameters.CaseCreationDateRangeTo = caseCreationDateRangeTo;
            }
            if (caseStatusFilter is not null)
            {
                cfg.QueryParameters.CaseStatusFilter = caseStatusFilter;
            }
            if (fieldgroups is not null)
            {
                cfg.QueryParameters.Fieldgroups = fieldgroups;
            }
            if (itemId is not null)
            {
                cfg.QueryParameters.ItemId = itemId;
            }
            if (limit is not null)
            {
                cfg.QueryParameters.Limit = limit;
            }
            if (offset is not null)
            {
                cfg.QueryParameters.Offset = offset;
            }
            if (orderId is not null)
            {
                cfg.QueryParameters.OrderId = orderId;
            }
            if (returnId is not null)
            {
                cfg.QueryParameters.ReturnId = returnId;
            }
            if (sort is not null)
            {
                cfg.QueryParameters.Sort = sort;
            }
            if (transactionId is not null)
            {
                cfg.QueryParameters.TransactionId = transactionId;
            }
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Create Inquiry
    /// </summary>
    public Task CreateInquiryAsync(
        CreateInquiryRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry.EmptyPathSegment.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Send Inquiry Message
    /// </summary>
    public Task SendInquiryMessageAsync(
        string inquiryId,
        SendMessageRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry[inquiryId].Send_message.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Escalate Inquiry
    /// </summary>
    public Task EscalateInquiryAsync(
        string inquiryId,
        EscalateInquiryRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry[inquiryId].Escalate.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Close Inquiry
    /// </summary>
    public Task CloseInquiryAsync(
        string inquiryId,
        BuyerCloseInquiryRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry[inquiryId].Close.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Confirm Inquiry Refund
    /// </summary>
    public Task ConfirmInquiryRefundAsync(
        string inquiryId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry[inquiryId].Confirm_refund.PostAsync(cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Get Inquiry
    /// </summary>
    public Task<InquiryDetailsResponse?> GetInquiryAsync(
        string inquiryId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry[inquiryId].GetAsync(cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Issue Inquiry Refund
    /// </summary>
    public Task<VoluntaryRefundResponse?> IssueInquiryRefundAsync(
        string inquiryId,
        InquiryVoluntaryRefundRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry[inquiryId].Issue_refund.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Provide Inquiry Shipment Info
    /// </summary>
    public Task ProvideInquiryShipmentInfoAsync(
        string inquiryId,
        ShipmentInfoRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry[inquiryId].Provide_shipment_info.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Search Inquiries
    /// </summary>
    public Task<InquirySearchResponse?> SearchInquiriesAsync(
        string? fieldgroups = null,
        string? inquiryCreationDateRangeFrom = null,
        string? inquiryCreationDateRangeTo = null,
        string? inquiryStatus = null,
        string? itemId = null,
        string? limit = null,
        string? offset = null,
        string? orderId = null,
        string? sort = null,
        string? transactionId = null,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry.Search.GetAsync(cfg =>
        {
            if (fieldgroups is not null)
            {
                cfg.QueryParameters.Fieldgroups = fieldgroups;
            }
            if (inquiryCreationDateRangeFrom is not null)
            {
                cfg.QueryParameters.InquiryCreationDateRangeFrom = inquiryCreationDateRangeFrom;
            }
            if (inquiryCreationDateRangeTo is not null)
            {
                cfg.QueryParameters.InquiryCreationDateRangeTo = inquiryCreationDateRangeTo;
            }
            if (inquiryStatus is not null)
            {
                cfg.QueryParameters.InquiryStatus = inquiryStatus;
            }
            if (itemId is not null)
            {
                cfg.QueryParameters.ItemId = itemId;
            }
            if (limit is not null)
            {
                cfg.QueryParameters.Limit = limit;
            }
            if (offset is not null)
            {
                cfg.QueryParameters.Offset = offset;
            }
            if (orderId is not null)
            {
                cfg.QueryParameters.OrderId = orderId;
            }
            if (sort is not null)
            {
                cfg.QueryParameters.Sort = sort;
            }
            if (transactionId is not null)
            {
                cfg.QueryParameters.TransactionId = transactionId;
            }
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Provide Inquiry Refund Info
    /// </summary>
    public Task ProvideInquiryRefundInfoAsync(
        string inquiryId,
        SellerProvideRefundInfoRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Inquiry[inquiryId].Provide_refund_info.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Create Return Request
    /// </summary>
    public Task CreateReturnRequestAsync(
        CreateReturnRequest body,
        string? fieldgroups = null,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return.PostAsync(body, cfg =>
        {
            if (fieldgroups is not null)
            {
                cfg.QueryParameters.Fieldgroups = fieldgroups;
            }
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Get Return
    /// </summary>
    public Task GetReturnAsync(
        string returnId,
        string? fieldgroups = null,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].GetAsync(cfg =>
        {
            if (fieldgroups is not null)
            {
                cfg.QueryParameters.Fieldgroups = fieldgroups;
            }
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Search Returns
    /// </summary>
    public Task SearchReturnsAsync(
        string? creationDateRangeFrom = null,
        string? creationDateRangeTo = null,
        string? itemId = null,
        string? limit = null,
        string? offset = null,
        string? orderId = null,
        string? returnId = null,
        string? returnState = null,
        string? role = null,
        string? sort = null,
        string? states = null,
        string? transactionId = null,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return.Search.GetAsync(cfg =>
        {
            if (creationDateRangeFrom is not null)
            {
                cfg.QueryParameters.CreationDateRangeFrom = creationDateRangeFrom;
            }
            if (creationDateRangeTo is not null)
            {
                cfg.QueryParameters.CreationDateRangeTo = creationDateRangeTo;
            }
            if (itemId is not null)
            {
                cfg.QueryParameters.ItemId = itemId;
            }
            if (limit is not null)
            {
                cfg.QueryParameters.Limit = limit;
            }
            if (offset is not null)
            {
                cfg.QueryParameters.Offset = offset;
            }
            if (orderId is not null)
            {
                cfg.QueryParameters.OrderId = orderId;
            }
            if (returnId is not null)
            {
                cfg.QueryParameters.ReturnId = returnId;
            }
            if (returnState is not null)
            {
                cfg.QueryParameters.ReturnState = returnState;
            }
            if (role is not null)
            {
                cfg.QueryParameters.Role = role;
            }
            if (sort is not null)
            {
                cfg.QueryParameters.Sort = sort;
            }
            if (states is not null)
            {
                cfg.QueryParameters.States = states;
            }
            if (transactionId is not null)
            {
                cfg.QueryParameters.TransactionId = transactionId;
            }
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Escalate Return
    /// </summary>
    public Task EscalateReturnAsync(
        string returnId,
        EscalateRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].Escalate.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Process Return Request
    /// </summary>
    public Task ProcessReturnRequestAsync(
        string returnId,
        DecideReturnRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].Decide.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Mark Return Received
    /// </summary>
    public Task MarkItemReceivedAsync(
        string returnId,
        MarkAsReceivedRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].Mark_as_received.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Issue Return Refund
    /// </summary>
    public Task IssueReturnRefundAsync(
        string returnId,
        IssueRefundRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].Issue_refund.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Get Shipment Tracking Info
    /// </summary>
    public Task GetShipmentTrackingInfoAsync(
        string returnId,
        string? carrierUsed = null,
        string? trackingNumber = null,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].Tracking.GetAsync(cfg =>
        {
            if (carrierUsed is not null)
            {
                cfg.QueryParameters.CarrierUsed = carrierUsed;
            }
            if (trackingNumber is not null)
            {
                cfg.QueryParameters.TrackingNumber = trackingNumber;
            }
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Send Return Message
    /// </summary>
    public Task SendReturnMessageAsync(
        string returnId,
        SendMessageRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].Send_message.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Add Shipping Label Info
    /// </summary>
    public Task AddShippingLabelInfoAsync(
        string returnId,
        ProvideLabelRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].Add_shipping_label.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Upload Return File
    /// </summary>
    public Task UploadReturnFileAsync(
        string returnId,
        UploadFileRequest body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].File.Upload.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Get Return Files
    /// </summary>
    public Task GetReturnFilesAsync(
        string returnId,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return[returnId].Files.GetAsync(cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Get Return Preferences
    /// </summary>
    public Task GetReturnPreferencesAsync(
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return.Preference.GetAsync(cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));

    /// <summary>
    /// Set Return Preferences
    /// </summary>
    public Task SetReturnPreferencesAsync(
        Stream body,
        string? accessToken = null,
        RequestOptions? requestOptions = null,
        CancellationToken ct = default)
        => RestInvocation.CallAsync(
            _tokenContext,
            accessToken,
            () => _kiota.PostOrder.V2.Return.Preference.PostAsync(body, cfg =>
        {
            RestInvocation.ApplyHeaders(cfg.Headers, _config, requestOptions);
        }, ct));
}
