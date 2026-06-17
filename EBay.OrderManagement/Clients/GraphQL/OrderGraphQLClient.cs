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
using EBay.OrderManagement.Exceptions;
using EBay.OrderManagement.Generated.GraphQL;
using StrawberryShake;
using System.Net;
using System.Text.Json;

namespace EBay.OrderManagement.Clients.GraphQL;

public sealed class OrderGraphQLClient
{
    private readonly IOrderManagementGraphQLClient? _client;
    private readonly DynamicGraphQLClient _dynamic;
    private readonly ITokenContext _tokenContext;

    internal OrderGraphQLClient(IOrderManagementGraphQLClient? client, DynamicGraphQLClient dynamic, ITokenContext tokenContext)
        => (_client, _dynamic, _tokenContext) = (client, dynamic, tokenContext);

    private void EnsureTypedClientAvailable()
    {
        if (_client is null)
            throw new NotSupportedException(
                "Typed GraphQL operations require DI. Use ExecuteRawUnsafeAsync for standalone mode.");
    }

    // ── Orders ────────────────────────────────────────────────────────────────

    public Task<IOrders_Orders?> OrdersAsync(
        OrdersInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.Orders.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.Orders;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IOrdersByIds_OrdersByIds?> OrdersByIdsAsync(
        OrdersByIdsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.OrdersByIds.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.OrdersByIds;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IMarkOrdersPaid_MarkOrdersPaid?> MarkOrdersPaidAsync(
        MarkOrdersPaidInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.MarkOrdersPaid.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.MarkOrdersPaid;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IBulkUpdateOrderTags_BulkUpdateOrderTags?> BulkUpdateOrderTagsAsync(
        BulkUpdateOrderTagsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.BulkUpdateOrderTags.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.BulkUpdateOrderTags;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IOrderLineItemsByIds_OrderLineItemsByIds?> OrderLineItemsByIdsAsync(
        OrderLineItemsByIdsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.OrderLineItemsByIds.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.OrderLineItemsByIds;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    // ── Cancellations ─────────────────────────────────────────────────────────

    public Task<ISellerContractCancellations_SellerContractCancellations?> SellerContractCancellationsAsync(
        SellerContractCancellationsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.SellerContractCancellations.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.SellerContractCancellations;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IContractCancellation_ContractCancellation?> ContractCancellationAsync(
        ContractCancellationInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ContractCancellation.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ContractCancellation;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ICreateOrderCancellation_CreateOrderCancellation?> CreateOrderCancellationAsync(
        CreateOrderCancellationInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.CreateOrderCancellation.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.CreateOrderCancellation;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IApproveContractCancellation_ApproveContractCancellation?> ApproveContractCancellationAsync(
        ApproveContractCancellationInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ApproveContractCancellation.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ApproveContractCancellation;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IDeclineContractCancellation_DeclineContractCancellation?> DeclineContractCancellationAsync(
        DeclineContractCancellationInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.DeclineContractCancellation.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.DeclineContractCancellation;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    // ── Returns ───────────────────────────────────────────────────────────────

    public Task<IOrderReturn_OrderReturn?> OrderReturnAsync(
        OrderReturnInput input, ExchangeAmountScenario scenario, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.OrderReturn.ExecuteAsync(input, scenario, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.OrderReturn;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ISellerOrderReturns_SellerOrderReturns?> SellerOrderReturnsAsync(
        SellerOrderReturnsInput input, ExchangeAmountScenario scenario, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.SellerOrderReturns.ExecuteAsync(input, scenario, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.SellerOrderReturns;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IApproveReturn_ApproveReturn?> ApproveReturnAsync(
        ApproveReturnInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ApproveReturn.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ApproveReturn;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IDeclineReturn_DeclineReturn?> DeclineReturnAsync(
        DeclineReturnInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.DeclineReturn.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.DeclineReturn;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IProcessReturnRefund_ProcessReturnRefund?> ProcessReturnRefundAsync(
        ProcessReturnRefundInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ProcessReturnRefund.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ProcessReturnRefund;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ICreateInStoreReturn_CreateInStoreReturn?> CreateInStoreReturnAsync(
        CreateInStoreReturnInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.CreateInStoreReturn.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.CreateInStoreReturn;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IAttachReturnShipmentLabel_AttachReturnShipmentLabel?> AttachReturnShipmentLabelAsync(
        AttachReturnShipmentLabelInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.AttachReturnShipmentLabel.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.AttachReturnShipmentLabel;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IRecordReturnLabelSentOffline_RecordReturnLabelSentOffline?> RecordReturnLabelSentOfflineAsync(
        RecordReturnLabelSentOfflineInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.RecordReturnLabelSentOffline.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.RecordReturnLabelSentOffline;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IRecordReturnReceived_RecordReturnReceived?> RecordReturnReceivedAsync(
        RecordReturnReceivedInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.RecordReturnReceived.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.RecordReturnReceived;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ISendReturnMessage_SendReturnMessage?> SendReturnMessageAsync(
        SendReturnMessageInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.SendReturnMessage.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.SendReturnMessage;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ISubmitReturnReferral_SubmitReturnReferral?> SubmitReturnReferralAsync(
        SubmitReturnReferralInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.SubmitReturnReferral.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.SubmitReturnReferral;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IProposeKeepItemWithPartialRefund_ProposeKeepItemWithPartialRefund?> ProposeKeepItemWithPartialRefundAsync(
        ProposeKeepItemWithPartialRefundInput input, ExchangeAmountScenario scenario, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ProposeKeepItemWithPartialRefund.ExecuteAsync(input, scenario, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ProposeKeepItemWithPartialRefund;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IProvideRmaNumber_ProvideRmaNumber?> ProvideRmaNumberAsync(
        ProvideRmaNumberInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ProvideRmaNumber.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ProvideRmaNumber;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    // ── Return Rules ──────────────────────────────────────────────────────────

    public Task<IReturnRuleListingGroup_ReturnRuleListingGroup?> ReturnRuleListingGroupAsync(
        ReturnRuleListingGroupInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ReturnRuleListingGroup.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ReturnRuleListingGroup;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ICreateReturnRuleListingGroup_CreateReturnRuleListingGroup?> CreateReturnRuleListingGroupAsync(
        CreateReturnRuleListingGroupInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.CreateReturnRuleListingGroup.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.CreateReturnRuleListingGroup;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IDeleteReturnRuleListingGroup_DeleteReturnRuleListingGroup?> DeleteReturnRuleListingGroupAsync(
        DeleteReturnRuleListingGroupInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.DeleteReturnRuleListingGroup.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.DeleteReturnRuleListingGroup;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IAddListingsToReturnRuleListingGroup_AddListingsToReturnRuleListingGroup?> AddListingsToReturnRuleListingGroupAsync(
        AddListingsToReturnRuleListingGroupInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.AddListingsToReturnRuleListingGroup.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.AddListingsToReturnRuleListingGroup;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ISellerReturnPreference_SellerReturnPreference?> SellerReturnPreferenceAsync(
        SellerReturnPreferenceInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.SellerReturnPreference.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.SellerReturnPreference;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IAppendSellerReturnResponseRule_AppendSellerReturnResponseRule?> AppendSellerReturnResponseRuleAsync(
        AppendSellerReturnResponseRuleInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.AppendSellerReturnResponseRule.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.AppendSellerReturnResponseRule;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IAppendSellerReturnToAddressRule_AppendSellerReturnToAddressRule?> AppendSellerReturnToAddressRuleAsync(
        AppendSellerReturnToAddressRuleInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.AppendSellerReturnToAddressRule.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.AppendSellerReturnToAddressRule;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IUpdateSellerReturnResponseRuleCondition_UpdateSellerReturnResponseRuleCondition?> UpdateSellerReturnResponseRuleConditionAsync(
        UpdateSellerReturnResponseRuleConditionInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.UpdateSellerReturnResponseRuleCondition.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.UpdateSellerReturnResponseRuleCondition;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IUpdateSellerReturnResponseRulesPriorities_UpdateSellerReturnResponseRulesPriorities?> UpdateSellerReturnResponseRulesPrioritiesAsync(
        UpdateSellerReturnResponseRulesPrioritiesInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.UpdateSellerReturnResponseRulesPriorities.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.UpdateSellerReturnResponseRulesPriorities;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IUpdateSellerReturnToAddressRuleCondition_UpdateSellerReturnToAddressRuleCondition?> UpdateSellerReturnToAddressRuleConditionAsync(
        UpdateSellerReturnToAddressRuleConditionInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.UpdateSellerReturnToAddressRuleCondition.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.UpdateSellerReturnToAddressRuleCondition;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IUpdateSellerReturnToAddressRulesPriorities_UpdateSellerReturnToAddressRulesPriorities?> UpdateSellerReturnToAddressRulesPrioritiesAsync(
        UpdateSellerReturnToAddressRulesPrioritiesInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.UpdateSellerReturnToAddressRulesPriorities.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.UpdateSellerReturnToAddressRulesPriorities;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IUpdateSellerReturnRuleStatus_UpdateSellerReturnRuleStatus?> UpdateSellerReturnRuleStatusAsync(
        UpdateSellerReturnRuleStatusInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.UpdateSellerReturnRuleStatus.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.UpdateSellerReturnRuleStatus;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IDeleteSellerReturnRule_DeleteSellerReturnRule?> DeleteSellerReturnRuleAsync(
        DeleteSellerReturnRuleInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.DeleteSellerReturnRule.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.DeleteSellerReturnRule;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IUpdateSellerRmaPreference_UpdateSellerRmaPreference?> UpdateSellerRmaPreferenceAsync(
        UpdateSellerRmaPreferenceInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.UpdateSellerRmaPreference.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.UpdateSellerRmaPreference;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    // ── Order Inquiries ───────────────────────────────────────────────────────

    public Task<IOrderInquiry_OrderInquiry?> OrderInquiryAsync(
        OrderInquiryInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.OrderInquiry.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.OrderInquiry;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ISellerOrderInquiries_SellerOrderInquiries?> SellerOrderInquiriesAsync(
        SellerOrderInquiriesInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.SellerOrderInquiries.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.SellerOrderInquiries;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ISendOrderInquiryMessage_SendOrderInquiryMessage?> SendOrderInquiryMessageAsync(
        SendOrderInquiryMessageInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.SendOrderInquiryMessage.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.SendOrderInquiryMessage;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IProcessOrderInquiryRefund_ProcessOrderInquiryRefund?> ProcessOrderInquiryRefundAsync(
        ProcessOrderInquiryRefundInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ProcessOrderInquiryRefund.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ProcessOrderInquiryRefund;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ISubmitOrderInquiryReferral_SubmitOrderInquiryReferral?> SubmitOrderInquiryReferralAsync(
        SubmitOrderInquiryReferralInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.SubmitOrderInquiryReferral.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.SubmitOrderInquiryReferral;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IProvideShipmentInfoForItemNotReceivedInquiry_ProvideShipmentInfoForItemNotReceivedInquiry?> ProvideShipmentInfoForItemNotReceivedInquiryAsync(
        ProvideShipmentInfoForItemNotReceivedInquiryInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ProvideShipmentInfoForItemNotReceivedInquiry.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ProvideShipmentInfoForItemNotReceivedInquiry;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    // ── Item Commitments ──────────────────────────────────────────────────────

    public Task<IItemCommitments_ItemCommitments?> ItemCommitmentsAsync(
        ItemCommitmentsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ItemCommitments.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ItemCommitments;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IItemCommitmentsByIds_ItemCommitmentsByIds?> ItemCommitmentsByIdsAsync(
        ItemCommitmentsByIdsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.ItemCommitmentsByIds.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.ItemCommitmentsByIds;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IMarkItemCommitmentsPaid_MarkItemCommitmentsPaid?> MarkItemCommitmentsPaidAsync(
        MarkItemCommitmentsPaidInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.MarkItemCommitmentsPaid.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.MarkItemCommitmentsPaid;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IBulkUpdateItemCommitmentTags_BulkUpdateItemCommitmentTags?> BulkUpdateItemCommitmentTagsAsync(
        BulkUpdateItemCommitmentTagsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.BulkUpdateItemCommitmentTags.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.BulkUpdateItemCommitmentTags;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ICreateItemCommitmentCancellation_CreateItemCommitmentCancellation?> CreateItemCommitmentCancellationAsync(
        CreateItemCommitmentCancellationInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.CreateItemCommitmentCancellation.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.CreateItemCommitmentCancellation;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    // ── Purchase Quotes ───────────────────────────────────────────────────────

    public Task<IPurchaseQuotes_PurchaseQuotes?> PurchaseQuotesAsync(
        PurchaseQuotesInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.PurchaseQuotes.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.PurchaseQuotes;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IPurchaseQuotesByIds_PurchaseQuotesByIds?> PurchaseQuotesByIdsAsync(
        PurchaseQuotesByIdsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.PurchaseQuotesByIds.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.PurchaseQuotesByIds;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IPurchaseQuoteLineItemsByIds_PurchaseQuoteLineItemsByIds?> PurchaseQuoteLineItemsByIdsAsync(
        PurchaseQuoteLineItemsByIdsInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.PurchaseQuoteLineItemsByIds.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.PurchaseQuoteLineItemsByIds;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ICreatePurchaseQuote_CreatePurchaseQuote?> CreatePurchaseQuoteAsync(
        CreatePurchaseQuoteInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.CreatePurchaseQuote.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.CreatePurchaseQuote;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ICreatePurchaseQuoteCancellation_CreatePurchaseQuoteCancellation?> CreatePurchaseQuoteCancellationAsync(
        CreatePurchaseQuoteCancellationInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.CreatePurchaseQuoteCancellation.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.CreatePurchaseQuoteCancellation;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IBulkUpdatePurchaseQuotes_BulkUpdatePurchaseQuotes?> BulkUpdatePurchaseQuotesAsync(
        BulkUpdatePurchaseQuotesInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.BulkUpdatePurchaseQuotes.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.BulkUpdatePurchaseQuotes;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<IRequestPurchaseQuote_RequestPurchaseQuote?> RequestPurchaseQuoteAsync(
        RequestPurchaseQuoteInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.RequestPurchaseQuote.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.RequestPurchaseQuote;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    public Task<ICommitToPurchase_CommitToPurchase?> CommitToPurchaseAsync(
        CommitToPurchaseInput input, string? accessToken = null, CancellationToken ct = default)
        => _tokenContext.RunAsync(accessToken, async () =>
        {
            EnsureTypedClientAvailable();
            try
            {
                var result = await _client!.CommitToPurchase.ExecuteAsync(input, ct).ConfigureAwait(false);
                EnsureNoErrors(result);
                return result.Data?.CommitToPurchase;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(ex);
            }
        });

    // ── Dynamic escape hatch ──────────────────────────────────────────────────

    /// <summary>
    /// Executes an arbitrary GraphQL query string against the API.
    /// <para>
    /// <b>WARNING — injection risk.</b> Never interpolate user-supplied input directly into
    /// <paramref name="query"/>. Always pass dynamic values via <paramref name="variables"/>
    /// so the server handles escaping. Treat this method like a raw SQL string: safe only
    /// with static, developer-controlled query text.
    /// </para>
    /// </summary>
    public Task<JsonDocument> ExecuteRawUnsafeAsync(
        string query, object? variables = null, string? accessToken = null, CancellationToken ct = default)
        => _dynamic.ExecuteRawUnsafeAsync(query, variables, accessToken, ct);

    // ── Error handling ────────────────────────────────────────────────────────

    private static void EnsureNoErrors<T>(IOperationResult<T> result) where T : class
    {
        if (result.Errors is { Count: > 0 })
        {
            var messages = result.Errors
                .Select(e => e.Message ?? e.Code ?? "unknown error")
                .ToArray();
            throw new GraphQLException(messages);
        }
    }
}
