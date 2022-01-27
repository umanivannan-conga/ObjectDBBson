using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ObjectDB.Runner
{
    public class BaseObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public LookupObject CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public LookupObject ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ExternalId { get; set; }
        public string Currency { get; set; }

        [JsonExtensionData]
        public Dictionary<string, object> CustomProperties { get; set; }

        public BaseObject()
        {
            CustomProperties = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
        }

        public T GetCustomFieldValue<T>(string fieldName)
        {
            if (CustomProperties.TryGetValue(fieldName, out object value))
            {
                if (value is JsonElement)
                {
                    var jsonElement = ((JsonElement)value);

                    switch (jsonElement.ValueKind)
                    {
                        case JsonValueKind.String:
                            value = jsonElement.GetString();
                            break;
                        case JsonValueKind.Number:
                            value = jsonElement.GetDouble();
                            break;
                        case JsonValueKind.False:
                            value = false;
                            break;
                        case JsonValueKind.True:
                            value = true;
                            break;
                        case JsonValueKind.Null:
                        case JsonValueKind.Undefined:
                            value = null;
                            break;
                    };
                }

                if (value is T)
                {
                    return (T)value;
                }
                else
                {
                    object propertyValue = default(T);

                    if (value != null)
                    {
                        var genericType = typeof(T);
                        genericType = Nullable.GetUnderlyingType(genericType) ?? genericType;

                        if (genericType == typeof(DateTime))
                        {
                            if (DateTime.TryParse(Convert.ToString(value), out DateTime convertedValue))
                            {
                                propertyValue = convertedValue;
                            }
                            else if (long.TryParse(Convert.ToString(value), out long ticks))
                            {
                                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                                propertyValue = epoch.AddMilliseconds(ticks);
                            }
                        }
                        else if (value is BaseObject && genericType.BaseType.Equals(typeof(BaseObject)))
                        {
                            propertyValue = value;
                        }
                        else
                        {
                            propertyValue = Convert.ChangeType(value, genericType);
                        }
                    }

                    return (T)propertyValue;
                }
            }

            return default(T);
        }

        public void SetCustomFieldValue(string propertyName, object value)
        {
            CustomProperties[propertyName] = value;
        }
    }

    public class LookupObject
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public LookupObject(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return System.Text.Json.JsonSerializer.Serialize(this);
        }
    }

    public class CurrencyField
    {
        public decimal Value { get; set; }
        [JsonInclude]
        public decimal DisplayValue { get; internal set; }

        public CurrencyField() { }

        public CurrencyField(decimal value)
        {
            Value = value;
        }

        public static implicit operator CurrencyField(decimal value)
        {
            return new() { Value = value };
        }

        public static explicit operator decimal(CurrencyField field)
        {
            return field.Value;
        }
    }

    public class MP_LineItem : BaseObject
    {
        //public decimal? FF_AdjustedPrice { get; set; }
        //public bool FF_ModifiedDateEqualsCreatedDate { get; set; }
        public LookupObject cartId { get; set; }
        public string CurrencyIsoCode { get; set; }
        public LookupObject ConfigurationId { get; set; }
        public LookupObject AdHocGroupId { get; set; }
        public string AddedByRuleInfo { get; set; }
        public string AddedBy { get; set; }
        public CurrencyField AdjustedPrice { get; set; }
        public decimal? AdjustmentAmount { get; set; }
        public string AdjustmentType { get; set; }
        public bool? AllocateGroupAdjustment { get; set; }
        public bool? AllowManualAdjustment { get; set; }
        public bool? AllowProration { get; set; }
        public bool? AllowRemoval { get; set; }
        public string AllowableAction { get; set; }
        public LookupObject AssetId { get; set; }
        public LookupObject AssetLineItemId { get; set; }
        public decimal? AssetQuantity { get; set; }
        public LookupObject AttributeValueId { get; set; }
        public bool? AutoRenew { get; set; }
        public decimal? AutoRenewalTerm { get; set; }
        public string AutoRenewalType { get; set; }
        public CurrencyField BaseCostOverride { get; set; }
        public CurrencyField BaseCost { get; set; }
        public CurrencyField BaseExtendedCost { get; set; }
        public CurrencyField BaseExtendedPrice { get; set; }
        public string BasePriceMethod { get; set; }
        public CurrencyField BasePriceOverride { get; set; }
        public CurrencyField BasePrice { get; set; }
        public LookupObject BaseProductId { get; set; }
        public LookupObject BillToAccountId { get; set; }
        public string BillingFrequency { get; set; }
        public LookupObject BillingPreferenceId { get; set; }
        public string BillingRule { get; set; }
        public LookupObject ChargeGroupId { get; set; }
        public string ChargeType { get; set; }
        public string ClassificationHierarchyInfo { get; set; }
        public string ClassificationHierarchy { get; set; }
        public LookupObject ClassificationId { get; set; }
        public decimal? CollaborationParentLineNumber { get; set; }
        public LookupObject CollaborationRequestId { get; set; }
        public string Comments { get; set; }
        public decimal? CommitmentQuantity { get; set; }
        public string ConfigStatus { get; set; }
        public string ConstraintCheckStatus { get; set; }
        public string ContractNumbers { get; set; }
        public decimal? CopySourceBundleNumber { get; set; }
        public decimal? CopySourceLineNumber { get; set; }
        public decimal? CopySourceNumber { get; set; }
        public CurrencyField Cost { get; set; }
        public string CouponCode { get; set; }
        public bool? Customizable { get; set; }
        public CurrencyField DeltaPrice { get; set; }
        public decimal? DeltaQuantity { get; set; }
        public LookupObject DerivedFromId { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public CurrencyField ExtendedCost { get; set; }
        public string ExtendedDescription { get; set; }
        public CurrencyField ExtendedPrice { get; set; }
        public decimal? ExtendedQuantity { get; set; }
        public CurrencyField FlatOptionPrice { get; set; }
        public string Frequency { get; set; }
        public decimal? GroupAdjustmentPercent { get; set; }
        public string Guidance { get; set; }
        public bool? HasAttributes { get; set; }
        public bool? HasBaseProduct { get; set; }
        public bool? HasDefaults { get; set; }
        public bool? HasIncentives { get; set; }
        public bool? HasOptions { get; set; }
        public bool? HasTieredPrice { get; set; }
        public bool? HideCopyAction { get; set; }
        public bool? HideInvoiceDisplay { get; set; }
        public CurrencyField IncentiveAdjustmentAmount { get; set; }
        public CurrencyField IncentiveBasePrice { get; set; }
        public string IncentiveCode { get; set; }
        public CurrencyField IncentiveExtendedPrice { get; set; }
        public LookupObject IncentiveId { get; set; }
        public string IncentiveType { get; set; }
        public bool? IsAssetPricing { get; set; }
        public bool? IsCustomPricing { get; set; }
        public bool? IsHidden { get; set; }
        public bool? IsOptionRollupLine { get; set; }
        public bool? IsOptional { get; set; }
        public bool? IsPrimaryLine { get; set; }
        public bool? IsPrimaryRampLine { get; set; }
        public bool? IsQuantityModifiable { get; set; }
        public bool? IsReadOnly { get; set; }
        public bool? IsSellingTermReadOnly { get; set; }
        public bool? IsUsageTierModifiable { get; set; }
        public decimal? ItemSequence { get; set; }
        public decimal? LineNumber { get; set; }
        public decimal? LineSequence { get; set; }
        public string LineStatus { get; set; }
        public string LineType { get; set; }
        public CurrencyField ListPrice { get; set; }
        public LookupObject LocationId { get; set; }
        public CurrencyField MaxPrice { get; set; }
        public decimal? MaxUsageQuantity { get; set; }
        public string MinMaxPriceAppliesTo { get; set; }
        public CurrencyField MinPrice { get; set; }
        public decimal? MinUsageQuantity { get; set; }
        public string NetAdjustmentPercent { get; set; } //decimal? 
        public CurrencyField NetPrice { get; set; }
        public CurrencyField NetUnitPrice { get; set; }
        public CurrencyField OptionCost { get; set; }
        public string OptionGroupLabel { get; set; }
        public LookupObject OptionId { get; set; }
        public CurrencyField OptionPrice { get; set; }
        public decimal? OptionSequence { get; set; }
        public LookupObject OrderLineItemId { get; set; }
        public string OrderLineStatus { get; set; }
        public decimal? ParentBundleNumber { get; set; }
        public LookupObject PaymentTermId { get; set; }
        public decimal? PriceAdjustmentAmount { get; set; }
        public string PriceAdjustmentAppliesTo { get; set; }
        public string PriceAdjustmentType { get; set; }
        public CurrencyField PriceAdjustment { get; set; }
        public string PriceGroup { get; set; }
        public bool? PriceIncludedInBundle { get; set; }
        public LookupObject PriceListId { get; set; }
        public LookupObject PriceListItemId { get; set; }
        public string PriceMethod { get; set; }
        public string PriceType { get; set; }
        public string PriceUom { get; set; }
        public DateTime? PricingDate { get; set; }
        public string PricingGuidance { get; set; }
        public string PricingStatus { get; set; }
        public string PricingSteps { get; set; }
        public decimal? PrimaryLineNumber { get; set; }
        public LookupObject ProductId { get; set; }
        public LookupObject ProductOptionId { get; set; }
        public decimal? ProductVersion { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? RelatedAdjustmentAmount { get; set; }
        public string RelatedAdjustmentAppliesTo { get; set; }
        public string RelatedAdjustmentType { get; set; }
        public LookupObject RelatedItemId { get; set; }
        public string RelatedPercentAppliesTo { get; set; }
        public CurrencyField RelatedPercent { get; set; }
        public decimal? RenewalAdjustmentAmount { get; set; }
        public string RenewalAdjustmentType { get; set; }
        public string RollupPriceMethod { get; set; }
        public bool? RollupPriceToBundle { get; set; }
        public string SellingFrequency { get; set; }
        public decimal? SellingTerm { get; set; }
        public string SellingUom { get; set; }
        public LookupObject ServiceLocationId { get; set; }
        public LookupObject ShipToAccountId { get; set; }
        public string StartDate { get; set; }
        public string StatusDetails { get; set; }
        public LookupObject SummaryGroupId { get; set; }
        public string SyncStatus { get; set; }
        public LookupObject TaxCodeId { get; set; }
        public bool? TaxInclusive { get; set; }
        public bool? Taxable { get; set; }
        public decimal? Term { get; set; }
        public decimal? TotalQuantity { get; set; }
        public LookupObject TransferPriceLineItemId { get; set; }
        public CurrencyField UnitCostAdjustment { get; set; }
        public CurrencyField UnitPriceAdjustmentAuto { get; set; }
        public CurrencyField UnitPriceAdjustmentManual { get; set; }
        public string Uom { get; set; }
        public string Apttus_CQApprov__Approval_Status { get; set; }
        public string ibmcBillingCodeTxt { get; set; }
        public string ibmcRealServiceFeatureCdTxt { get; set; }
        public string ibmcPriceReferenceDate { get; set; }
        public string ibmcprerequisiteProductId { get; set; }
        public string IBMC_Approval_Key { get; set; }
        public CurrencyField IBMC_Extended_List_Price { get; set; }
        public string IBMC_Financial_Approval_Key { get; set; }
        public string Product_Name { get; set; }
        public CurrencyField SellCostPct { get; set; }
        public LookupObject ibmcAccountFilterId { get; set; }
        public string ibmcAllowedServiceFeatureCd { get; set; }
        public string ibmcAllowedServices { get; set; }
        public CurrencyField ibmcAnnualListPriceAmt { get; set; }
        public decimal? ibmcApprovalLevel { get; set; }
        public bool? ibmcApprovalRequiredInd { get; set; }
        public string ibmcAssetDescTxt { get; set; }
        public CurrencyField ibmcBPNetPriceAmt { get; set; }
        public CurrencyField ibmcBasePriceAmt { get; set; }
        public string ibmcCartGrouping { get; set; }
        public string ibmcCaseNumber { get; set; }
        public string ibmcConfigFileId { get; set; }
        public string ibmcConfigFileVerNum { get; set; }
        public bool? ibmcConfigurationChangeInd { get; set; }
        public LookupObject ibmcCountryId { get; set; }
        public string ibmcCustomerSiteId { get; set; }
        public string ibmcDateofActivity { get; set; }
        public decimal? ibmcDealMaxNum { get; set; }
        public string ibmcDelegationThesholdTxt { get; set; }
        public decimal? ibmcDiscountThresholdNum { get; set; }
        public string ibmcDocumentId { get; set; }
        public string ibmcEmpCountry { get; set; }
        public string ibmcEmpSerialNumber { get; set; }
        public string ibmcEndOfServiceDt { get; set; }
        public string ibmcErrorOrWarningTxt { get; set; }
        public decimal? ibmcExpenses { get; set; }
        public decimal? ibmcFeatureQtyAmt { get; set; }
        public decimal? ibmcGroupGP { get; set; }
        public string ibmcHWDt { get; set; }
        public string ibmcHWProdDesc { get; set; }
        public string ibmcHWProductId { get; set; }
        public string ibmcHWSerialNum { get; set; }
        public LookupObject ibmcInstallCustomerAccountId { get; set; }
        public string ibmcInstallCustomerId { get; set; }
        public string ibmcInstallDt { get; set; }
        public bool? ibmcIsDuplicateInd { get; set; }
        public string ibmcLICountryId { get; set; }
        public string ibmcLiabilityIndicator { get; set; }
        public bool? ibmcLineToBeDeleted { get; set; }
        public bool? ibmcLineToBeSent { get; set; }
        public LookupObject ibmcLinkedToPrevLineItemId { get; set; }
        public bool? ibmcMandatoryServiceInd { get; set; }
        public bool? ibmcMandatoryServiceLineInd { get; set; }
        public string ibmcMaxServiceEndDt { get; set; }
        public string ibmcMaximumEndDate { get; set; }
        public string ibmcMessagesTxt { get; set; }
        public string ibmcMicroServiceResponse { get; set; }
        public string ibmcMinServiceStartDt { get; set; }
        public string ibmcMinimumStartDate { get; set; }
        public string ibmcModelFeatureTxt { get; set; }
        public CurrencyField ibmcNetGPNum { get; set; }
        public CurrencyField ibmcNetGPPct { get; set; }
        public CurrencyField ibmcNetPriceAmt { get; set; }
        public string ibmcObjectofServiceType { get; set; }
        public string ibmcPartsNo { get; set; }
        public decimal? ibmcPartsQty { get; set; }
        public string ibmcPlatformTxt { get; set; }
        public string ibmcPrePay { get; set; }
        public string ibmcPreviousEndDate { get; set; }
        public string ibmcPreviousServiceLevel { get; set; }
        public string ibmcPreviousStartDate { get; set; }
        public string ibmcPriceLineStatusTxt { get; set; }
        public string ibmcPricerGrouping { get; set; }
        public string ibmcProductCode { get; set; }
        public string ibmcQuoteTerm { get; set; }
        public string ibmcSWDt { get; set; }
        public string ibmcSWProdDesc { get; set; }
        public string ibmcSWProductID { get; set; }
        public string ibmcSWSerialNum { get; set; }
        public string ibmcSerialNum { get; set; }
        public bool? ibmcServFeatModInd { get; set; }
        public bool? ibmcServiceEndDateModifiableInd { get; set; }
        public string ibmcServiceFeatureCd { get; set; }
        public string ibmcServiceFeatureDesc { get; set; }
        public bool? ibmcServiceFeatureModifiableInd { get; set; }
        public string ibmcServiceLevel { get; set; }
        public string ibmcShaCommentTxt { get; set; }
        public decimal? ibmcTotalHours { get; set; }
        public string ibmcTrasactionTypeTxt { get; set; }
        public decimal? ibmcTravelHours { get; set; }
        public string ibmcTypeTxt { get; set; }
        public string ibmcWarrantyEndDt { get; set; }
        public CurrencyField ibmcYear1BPNetPriceAmt { get; set; }
        public CurrencyField ibmcYearOneListPriceAmt { get; set; }
        public CurrencyField ibmcYearOneNetPriceAmt { get; set; }
        public CurrencyField ibmc_bpExhibitDiscountPct { get; set; }
        public string ibmcofferingGroupOrderCd { get; set; }
        public bool? ibmcserviceStartDateModifiableInd { get; set; }
        public string ibmcsowPrintGroupCd { get; set; }
        public string ibmctype_model_serialNumber { get; set; }
        public string ibmcRealServiceFeatureDesc { get; set; }
        public bool? ibmcIsBPRejectionNeeded { get; set; }
        public string ibmcBillReasonCodeTxt { get; set; }
        public bool? ibmcExcludePrePayTermDiscount { get; set; }
        public string ibmcTermReasonCodeTxt { get; set; }
        public string ibmcConversionRateVersion { get; set; }
        public CurrencyField ibmcExtendedAnnualListPrice { get; set; }
        public string ibmcCurrencyExchangeRateVersion { get; set; }
        public decimal? ibmcCurrencyExchangeRate { get; set; }
        public string ibmcFinDivisionCd { get; set; }
        public CurrencyField Net_Price_without_Fees { get; set; }
        public string ibmcApproval_type { get; set; }
        public CurrencyField ibmcBPNetPrice_withVATAmt { get; set; }
        public bool? ibmcLineManuallyDeleted { get; set; }
        public CurrencyField ibmcNetGPwithoutFees { get; set; }
        public CurrencyField ibmcNetPrice_withVATAmt { get; set; }
        public string ibmcTransactionID { get; set; }
        public CurrencyField ibmcVATAmountAmt { get; set; }
        public CurrencyField ibmcVATPct { get; set; }
        public CurrencyField ibmcVolumeDisc { get; set; }
        public CurrencyField ibmcYear1NetPrice_withVATAmt { get; set; }
        public CurrencyField ibmcYear1_BPNetPrice_withVATAmt { get; set; }
        public string IbmcExcludedServices { get; set; }
        public string ibmcConfigSource { get; set; }
        public bool? ibmcIsePricerquote { get; set; }
        public string ibmcBillingFreqInd { get; set; }
        public decimal? ibmcPrepayDisc { get; set; }
        public decimal? ibmcTermDisc { get; set; }
        public string ibmcLastEntitlementDate { get; set; }
        public string ibmcWorkOrderDesc { get; set; }
        public string ibmcWorkOrderNum { get; set; }
        public bool? ibmcNetPriceChanged { get; set; }
        public string ibmcNonFinApprovalKey { get; set; }
        public CurrencyField ibmcOldNetPrice { get; set; }
        public string ibmcApprovalKey2 { get; set; }
        public string ibmcCOLABaseDate { get; set; }
        public decimal? ibmcCOLABaseIndex { get; set; }
        public string ibmcCOLACurrentIndexDate { get; set; }
        public decimal? ibmcCOLAIndex { get; set; }
        public string ibmcCOLANextIndexDate { get; set; }
        public string ibmcCOLAPublishIndexDate { get; set; }
        public string ibmcCOLAPublishIndex { get; set; }
        public CurrencyField ibmcOriginalListPrice { get; set; }
        public CurrencyField ibmcBPNetPrice_wVATAmt { get; set; }
        public CurrencyField ibmcNetPrice_wVATAmt { get; set; }
        public CurrencyField ibmcYear1NetPrice_wVATAmt { get; set; }
        public CurrencyField ibmcYear1_BPNetPrice_wVATAmt { get; set; }
        public string ibmclegacyContractID { get; set; }
        public LookupObject ibmcRelatedAssetLIID { get; set; }
        public CurrencyField ibmcTotalBilledAmount { get; set; }
        public LookupObject ibmcInitialAgreementId { get; set; }
        public LookupObject ibmcPrevAutoRenewalAgrmntId { get; set; }
        public string ibmcexternalAgreementRelatedLineItemId { get; set; }
        public string ibmcrelatedLineItemId { get; set; }
        public string ibmcUniqueID { get; set; }
        public CurrencyField ibmcUnitPrice { get; set; }
        public bool? ibmcMissingListPrice { get; set; }
        public bool? ibmcAutoRenewInd { get; set; }
        public decimal? ibmcSpecialDiscountPercentage { get; set; }
        public decimal? ibmcFBSExhibitPercentage { get; set; }
        public string ibmcAllowedServFeat3 { get; set; }
        public string ibmcAltStartDate { get; set; }
        public string ibmcDestSiteID { get; set; }
        public string ibmcLinkPrevTransID { get; set; }
        public decimal? ibmcMachineWeight { get; set; }
        public decimal? ibmcMaxQuantity { get; set; }
        public string ibmcQuoteConfigFreezeDate { get; set; }
        public string ibmcRelatedPriceOffId { get; set; }
        public string ibmcServiceFeature3 { get; set; }
        public string ibmcSimilarHWProdID { get; set; }
        public CurrencyField ibmcApprovedPrice { get; set; }
        public List<string> ibmcapprovedTypes { get; set; }
        public CurrencyField ibmcTCVLegacy { get; set; }
    }

}
