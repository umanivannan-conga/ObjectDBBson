
using ObjectDB;
using ObjectDB.Runner;
using System.Diagnostics;


var collection = new ObjectCollection<MP_LineItem>();
var lineItems = GetMP_LineItems(1000);

var ex1 = BsonExpression.Create("SUBSTRING($.x, 0, 3) + SUBSTRING($.x, 0, 3)");

var ex2 = BsonExpression.Create("$.x + ' ' +$.y");

var ex3 = BsonExpression.Create("$.cartId.Name");

var doc1 = new BsonDocument();

doc1 = new BsonDocument();

doc1["x"] = "Umamaheswaran";

doc1["y"] = "Manivannan";

var mapper = new BsonMapper();

var doc2 = mapper.ToDocument(lineItems[0]);

var r1 = ex1.ExecuteScalar(doc1);

var r2 = ex2.ExecuteScalar(doc1);

var r3 = ex3.ExecuteScalar(doc2);

System.Console.WriteLine(r1.AsString);
System.Console.WriteLine(r2.AsString);
System.Console.WriteLine(doc1.AsString);
collection.Insert(lineItems);

#region Load Data
static List<MP_LineItem> GetMP_LineItems(int recordCount)
{
    List<MP_LineItem> lines = new List<MP_LineItem>();

    for (int i = 1; i <= recordCount; i++)
    {
        var lineItemObj = new MP_LineItem()
        {
            cartId = new LookupObject("20bd7a08-8d3b-4881-b5a4-2f7a89dd4327", "Test"),
            Name = $"Name - {i}",
            AddedBy = "User", // $"AddedBy - {i}",
            AddedByRuleInfo = $"AddedByRuleInfo - {i}",
            AdjustedPrice = i,
            AdjustmentAmount = i,
            AdjustmentType = "Price Override", //$"AdjustmentType - {i}",
            AllocateGroupAdjustment = i % 2 == 0,
            AllowableAction = "Adjust Upwards", //$"AllowableAction - {i}",
            AllowManualAdjustment = i % 2 == 0,
            AllowProration = i % 2 == 0,
            AllowRemoval = i % 2 == 0,
            AssetQuantity = i,
            Apttus_CQApprov__Approval_Status = "Not Submitted",  //$"Apttus_CQApprov__Approval_Status - {i}",
            AutoRenew = i % 2 == 0,
            AutoRenewalTerm = i,
            AutoRenewalType = "Evergreen", //$"AutoRenewalType - {i}",
            BaseCost = i,
            BaseCostOverride = i,
            BaseExtendedCost = i,
            BaseExtendedPrice = i,
            BasePrice = i,
            BasePriceMethod = "Flat Price", //$"BasePriceMethod - {i}",
            BasePriceOverride = i,
            BillingFrequency = "Half Yearly", //$"BillingFrequency - {i}",
            BillingRule = "Milestone Billing", // $"BillingRule - {i}",
            ChargeType = "Standard Price", // $"ChargeType - {i}",
            ClassificationHierarchy = $"ClassificationHierarchy - {i}",
            ClassificationHierarchyInfo = $"ClassificationHierarchyInfo - {i}",
            CollaborationParentLineNumber = i,
            Comments = $"Comments - {i}",
            CommitmentQuantity = i,
            ConfigStatus = "Complete", //$"ConfigStatus - {i}",
            ConstraintCheckStatus = "NA", //$"ConstraintCheckStatus - {i}",
            ContractNumbers = $"ContractNumbers - {i}",
            CopySourceBundleNumber = i,
            CopySourceLineNumber = i,
            CopySourceNumber = i,
            Cost = i,
            CouponCode = $"CouponCode - {i}",
            //CreatedBy = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            CreatedDate = DateTime.UtcNow,
            Currency = "USD", // $"Currency - {i}",
            CurrencyIsoCode = "USD", // $"CurrencyIsoCode - {i}",
            Customizable = i % 2 == 0,
            CustomProperties = new System.Collections.Generic.Dictionary<string, object>(),
            DeltaPrice = i,
            DeltaQuantity = i,
            Description = $"Description - {i}",
            EndDate = $"EndDate - {i}",
            ExtendedCost = i,
            ExtendedDescription = $"ExtendedDescription - {i}",
            ExtendedPrice = i,
            ExtendedQuantity = i,
            ExternalId = $"ExternalId - {i}",
            FlatOptionPrice = i,
            Frequency = "Yearly", // $"Frequency - {i}",
            GroupAdjustmentPercent = i,
            Guidance = "Green", // $"Guidance - {i}",
            HasAttributes = i % 2 == 0,
            HasBaseProduct = i % 2 == 0,
            HasDefaults = i % 2 == 0,
            HasIncentives = i % 2 == 0,
            HasOptions = i % 2 == 0,
            HasTieredPrice = i % 2 == 0,
            HideCopyAction = i % 2 == 0,
            HideInvoiceDisplay = i % 2 == 0,
            ibmcAllowedServFeat3 = $"ibmcAllowedServFeat3 - {i}",
            ibmcAllowedServiceFeatureCd = $"ibmcAllowedServiceFeatureCd - {i}",
            ibmcAllowedServices = $"ibmcAllowedServices - {i}",
            ibmcAltStartDate = $"ibmcAltStartDate - {i}",
            ibmcAnnualListPriceAmt = i,
            ibmcApprovalKey2 = $"ibmcApprovalKey2 - {i}",
            ibmcApprovalLevel = i,
            ibmcApprovalRequiredInd = i % 2 == 0,
            ibmcApproval_type = $"ibmcApproval_type - {i}",
            ibmcApprovedPrice = i,
            //ibmcapprovedTypes = new List<string>() { "HW Re-Fee-Power" }, //$"ibmcapprovedTypes - {i}",
            ibmcAssetDescTxt = $"ibmcAssetDescTxt - {i}",
            ibmcAutoRenewInd = i % 2 == 0,
            ibmcBasePriceAmt = i,
            ibmcBillingCodeTxt = $"ibmcBillingCodeTxt - {i}",
            ibmcBillingFreqInd = $"ibmcBillingFreqInd - {i}",
            ibmcBillReasonCodeTxt = "MOD", // $"ibmcBillReasonCodeTxt - {i}",
            ibmcBPNetPriceAmt = i,
            ibmcBPNetPrice_withVATAmt = i,
            ibmcBPNetPrice_wVATAmt = i,
            ibmcCartGrouping = $"ibmcCartGrouping - {i}",
            ibmcCaseNumber = $"ibmcCaseNumber - {i}",
            ibmcCOLABaseDate = $"ibmcCOLABaseDate - {i}",
            ibmcCOLABaseIndex = i,
            ibmcCOLACurrentIndexDate = $"ibmcCOLACurrentIndexDate - {i}",
            ibmcCOLAIndex = i,
            ibmcCOLANextIndexDate = $"ibmcCOLANextIndexDate - {i}",
            ibmcCOLAPublishIndex = $"ibmcCOLAPublishIndex - {i}",
            ibmcCOLAPublishIndexDate = $"ibmcCOLAPublishIndexDate - {i}",
            ibmcConfigFileId = $"ibmcConfigFileId - {i}",
            ibmcConfigFileVerNum = $"ibmcConfigFileVerNum - {i}",
            ibmcConfigSource = $"ibmcConfigSource - {i}",
            ibmcConfigurationChangeInd = i % 2 == 0,
            ibmcConversionRateVersion = $"ibmcConversionRateVersion - {i}",
            ibmcCurrencyExchangeRate = i,
            ibmcCurrencyExchangeRateVersion = $"ibmcCurrencyExchangeRateVersion - {i}",
            ibmcCustomerSiteId = $"ibmcCustomerSiteId - {i}",
            ibmcDateofActivity = $"ibmcDateofActivity - {i}",
            ibmcDealMaxNum = i,
            ibmcDelegationThesholdTxt = $"ibmcDelegationThesholdTxt - {i}",
            ibmcDestSiteID = $"ibmcDestSiteID - {i}",
            ibmcDiscountThresholdNum = i,
            ibmcDocumentId = $"ibmcDocumentId - {i}",
            ibmcEmpCountry = $"ibmcEmpCountry - {i}",
            ibmcEmpSerialNumber = $"ibmcEmpSerialNumber - {i}",
            ibmcEndOfServiceDt = $"ibmcEndOfServiceDt - {i}",
            ibmcErrorOrWarningTxt = $"ibmcErrorOrWarningTxt - {i}",
            IbmcExcludedServices = $"IbmcExcludedServices - {i}",
            ibmcExcludePrePayTermDiscount = i % 2 == 0,
            ibmcExpenses = i,
            ibmcExtendedAnnualListPrice = i,
            ibmcexternalAgreementRelatedLineItemId = $"ibmcexternalAgreementRelatedLineItemId - {i}",
            ibmcFBSExhibitPercentage = i,
            ibmcFeatureQtyAmt = i,
            ibmcFinDivisionCd = $"ibmcFinDivisionCd - {i}",
            ibmcGroupGP = i,
            ibmcHWDt = $"ibmcHWDt - {i}",
            ibmcHWProdDesc = $"ibmcHWProdDesc - {i}",
            ibmcHWProductId = $"ibmcHWProductId - {i}",
            ibmcHWSerialNum = $"ibmcHWSerialNum - {i}",
            ibmcInstallCustomerId = $"ibmcInstallCustomerId - {i}",
            ibmcInstallDt = $"ibmcInstallDt - {i}",
            ibmcIsBPRejectionNeeded = i % 2 == 0,
            ibmcIsDuplicateInd = i % 2 == 0,
            ibmcIsePricerquote = i % 2 == 0,
            ibmcLastEntitlementDate = $"ibmcLastEntitlementDate - {i}",
            ibmclegacyContractID = $"ibmclegacyContractID - {i}",
            ibmcLiabilityIndicator = $"ibmcLiabilityIndicator - {i}",
            ibmcLICountryId = $"ibmcLICountryId - {i}",
            ibmcLineManuallyDeleted = i % 2 == 0,
            ibmcLineToBeDeleted = i % 2 == 0,
            ibmcLineToBeSent = i % 2 == 0,
            ibmcLinkPrevTransID = $"ibmcLinkPrevTransID - {i}",
            ibmcMachineWeight = i,
            ibmcMandatoryServiceInd = i % 2 == 0,
            ibmcMandatoryServiceLineInd = i % 2 == 0,
            ibmcMaximumEndDate = $"ibmcMaximumEndDate - {i}",
            ibmcMaxQuantity = i,
            ibmcMaxServiceEndDt = $"ibmcMaxServiceEndDt - {i}",
            ibmcMessagesTxt = $"ibmcMessagesTxt - {i}",
            ibmcMicroServiceResponse = $"ibmcMicroServiceResponse - {i}",
            ibmcMinimumStartDate = $"ibmcMinimumStartDate - {i}",
            ibmcMinServiceStartDt = $"ibmcMinServiceStartDt - {i}",
            ibmcMissingListPrice = i % 2 == 0,
            ibmcModelFeatureTxt = $"ibmcModelFeatureTxt - {i}",
            ibmcNetGPNum = i,
            ibmcNetGPPct = i,
            ibmcNetGPwithoutFees = i,
            ibmcNetPrice_withVATAmt = i,
            ibmcNetPrice_wVATAmt = i,
            ibmcNetPriceAmt = i,
            ibmcNetPriceChanged = i % 2 == 0,
            ibmcNonFinApprovalKey = $"ibmcNonFinApprovalKey - {i}",
            ibmcObjectofServiceType = $"ibmcObjectofServiceType - {i}",
            ibmcofferingGroupOrderCd = $"ibmcofferingGroupOrderCd - {i}",
            ibmcOldNetPrice = i,
            ibmcOriginalListPrice = i,
            ibmcPartsNo = $"ibmcPartsNo - {i}",
            ibmcPartsQty = i,
            ibmcPlatformTxt = $"ibmcPlatformTxt - {i}",
            ibmcPrePay = $"ibmcPrePay - {i}",
            ibmcPrepayDisc = i,
            ibmcprerequisiteProductId = $"ibmcprerequisiteProductId - {i}",
            ibmcPreviousEndDate = $"ibmcPreviousEndDate - {i}",
            ibmcPreviousServiceLevel = "M12F", // $"ibmcPreviousServiceLevel - {i}",
            ibmcPreviousStartDate = $"ibmcPreviousStartDate - {i}",
            ibmcPriceLineStatusTxt = $"ibmcPriceLineStatusTxt - {i}",
            ibmcPriceReferenceDate = $"ibmcPriceReferenceDate - {i}",
            ibmcPricerGrouping = $"ibmcPricerGrouping - {i}",
            ibmcProductCode = $"ibmcProductCode - {i}",
            ibmcQuoteConfigFreezeDate = $"ibmcQuoteConfigFreezeDate - {i}",
            ibmcQuoteTerm = $"ibmcQuoteTerm - {i}",
            ibmcRealServiceFeatureCdTxt = $"ibmcRealServiceFeatureCdTxt - {i}",
            ibmcRealServiceFeatureDesc = $"ibmcRealServiceFeatureDesc - {i}",
            ibmcrelatedLineItemId = $"ibmcrelatedLineItemId - {i}",
            ibmcRelatedPriceOffId = $"ibmcRelatedPriceOffId - {i}",
            ibmcSerialNum = $"ibmcSerialNum - {i}",
            ibmcServFeatModInd = i % 2 == 0,
            ibmcServiceEndDateModifiableInd = i % 2 == 0,
            ibmcServiceFeature3 = "Z110", // $"ibmcServiceFeature3 - {i}",
            ibmcServiceFeatureCd = $"ibmcServiceFeatureCd - {i}",
            ibmcServiceFeatureDesc = $"ibmcServiceFeatureDesc - {i}",
            ibmcServiceFeatureModifiableInd = i % 2 == 0,
            ibmcServiceLevel = "Z122", // $"ibmcServiceLevel - {i}",
            ibmcserviceStartDateModifiableInd = i % 2 == 0,
            ibmcShaCommentTxt = $"ibmcShaCommentTxt - {i}",
            ibmcSimilarHWProdID = $"ibmcSimilarHWProdID - {i}",
            ibmcsowPrintGroupCd = $"ibmcsowPrintGroupCd - {i}",
            ibmcSpecialDiscountPercentage = i,
            ibmcSWDt = $"ibmcSWDt - {i}",
            ibmcSWProdDesc = $"ibmcSWProdDesc - {i}",
            ibmcSWProductID = $"ibmcSWProductID - {i}",
            ibmcSWSerialNum = $"ibmcSWSerialNum - {i}",
            ibmcTCVLegacy = i,
            ibmcTermDisc = i,
            ibmcTermReasonCodeTxt = "SEL", //$"ibmcTermReasonCodeTxt - {i}",
            ibmcTotalBilledAmount = i,
            ibmcTotalHours = i,
            ibmcTransactionID = $"ibmcTransactionID - {i}",
            ibmcTrasactionTypeTxt = $"ibmcTrasactionTypeTxt - {i}",
            ibmcTravelHours = i,
            ibmctype_model_serialNumber = $"ibmctype_model_serialNumber - {i}",
            ibmcTypeTxt = $"ibmcTypeTxt - {i}",
            ibmcUniqueID = $"ibmcUniqueID - {i}",
            ibmcUnitPrice = i,
            ibmcVATAmountAmt = i,
            ibmcVATPct = i,
            ibmcVolumeDisc = i,
            ibmcWarrantyEndDt = $"ibmcWarrantyEndDt - {i}",
            ibmcWorkOrderDesc = $"ibmcWorkOrderDesc - {i}",
            ibmcWorkOrderNum = $"ibmcWorkOrderNum - {i}",
            ibmcYear1_BPNetPrice_withVATAmt = i,
            ibmcYear1_BPNetPrice_wVATAmt = i,
            ibmcYear1BPNetPriceAmt = i,
            ibmcYear1NetPrice_withVATAmt = i,
            ibmcYear1NetPrice_wVATAmt = i,
            ibmcYearOneListPriceAmt = i,
            ibmcYearOneNetPriceAmt = i,
            IncentiveAdjustmentAmount = i,
            IncentiveBasePrice = i,
            IncentiveCode = $"IncentiveCode - {i}",
            IncentiveExtendedPrice = i,
            IncentiveType = "Promotion", // $"IncentiveType - {i}",
            IsAssetPricing = i % 2 == 0,
            IsCustomPricing = i % 2 == 0,
            IsHidden = i % 2 == 0,
            IsOptional = i % 2 == 0,
            IsOptionRollupLine = i % 2 == 0,
            IsPrimaryLine = i % 2 == 0,
            IsPrimaryRampLine = i % 2 == 0,
            IsQuantityModifiable = i % 2 == 0,
            IsReadOnly = i % 2 == 0,
            IsSellingTermReadOnly = i % 2 == 0,
            IsUsageTierModifiable = i % 2 == 0,
            ItemSequence = i,
            LineNumber = i,
            LineSequence = i,
            LineStatus = i % 3 == 1 ? "New" : i % 2 == 0 ? "Existing" : "Renewed", //$"LineStatus - {i}",
            LineType = "Product/Service", //$"LineType - {i}",
            ListPrice = i,
            MaxPrice = i,
            MaxUsageQuantity = i,
            MinMaxPriceAppliesTo = "Base Extended Price", // $"MinMaxPriceAppliesTo - {i}",
            MinPrice = i,
            MinUsageQuantity = i,
            NetAdjustmentPercent = $"{i}",
            NetPrice = i,
            NetUnitPrice = i,
            OptionCost = i,
            OptionGroupLabel = $"OptionGroupLabel - {i}",
            OptionPrice = i,
            OptionSequence = i,
            OrderLineStatus = "Draft", //$"OrderLineStatus - {i}",
            ParentBundleNumber = i,
            PriceAdjustment = i,
            PriceAdjustmentAmount = i,
            PriceAdjustmentAppliesTo = "Base Extended Price", //$"PriceAdjustmentAppliesTo - {i}",
            PriceAdjustmentType = "Markup Amount", //$"PriceAdjustmentType - {i}",
            PriceGroup = "Price Ramp", // $"PriceGroup - {i}",
            PriceIncludedInBundle = i % 2 == 0,
            PriceMethod = "Flat Price", // $"PriceMethod - {i}",
            PriceType = "One Time", // $"PriceType - {i}",
            PriceUom = "Each", //$"PriceUom - {i}",
            PricingGuidance = $"PricingGuidance - {i}",
            PricingStatus = "Complete", //$"PricingStatus - {i}",
            PricingSteps = $"PricingSteps - {i}",
            PrimaryLineNumber = i,
            ProductVersion = i,
            Quantity = i,
            RelatedAdjustmentAmount = i,
            RelatedAdjustmentAppliesTo = "Base Extended Price", // $"RelatedAdjustmentAppliesTo - {i}",
            RelatedAdjustmentType = "Markup Amount", // $"RelatedAdjustmentType - {i}",
            RelatedPercent = i,
            RelatedPercentAppliesTo = "Base Extended Price", //$"RelatedPercentAppliesTo - {i}",
            RenewalAdjustmentAmount = i,
            RenewalAdjustmentType = "Uplift Amount", // $"RenewalAdjustmentType - {i}",
            RollupPriceMethod = "Flat Price", // $"RollupPriceMethod - {i}",
            RollupPriceToBundle = i % 2 == 0,
            SellingFrequency = "Half Yearly", //$"SellingFrequency - {i}",
            SellingTerm = i,
            SellingUom = "Each", // $"SellingUom - {i}",
            StartDate = $"StartDate - {i}",
            StatusDetails = $"StatusDetails - {i}",
            SyncStatus = "Post-Pricing Pending", // $"SyncStatus - {i}",
            Taxable = i % 2 == 0,
            TaxInclusive = i % 2 == 0,
            Term = i,
            TotalQuantity = i,
            UnitCostAdjustment = i,
            UnitPriceAdjustmentAuto = i,
            UnitPriceAdjustmentManual = i,
            Uom = "Each", //$"Uom - {i}",
            IBMC_Approval_Key = $"IBMC_Approval_Key - {i}",
            ibmc_bpExhibitDiscountPct = i,
            IBMC_Extended_List_Price = i,
            IBMC_Financial_Approval_Key = $"IBMC_Financial_Approval_Key - {i}",
            //ModifiedDate = DateTime.UtcNow,

            Net_Price_without_Fees = i,
            PricingDate = DateTime.UtcNow,
            Product_Name = $"Product_Name - {i}",
            SellCostPct = i,
            AdHocGroupId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ibmcLinkedToPrevLineItemId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ibmcInitialAgreementId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ibmcInstallCustomerAccountId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ibmcCountryId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ibmcAccountFilterId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            DerivedFromId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),

            AssetId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            AssetLineItemId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            AttributeValueId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            BaseProductId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            BillingPreferenceId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            BillToAccountId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ChargeGroupId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ClassificationId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            CollaborationRequestId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ConfigurationId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),

            ibmcPrevAutoRenewalAgrmntId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ibmcRelatedAssetLIID = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            IncentiveId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            LocationId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            OptionId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            OrderLineItemId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            PaymentTermId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            PriceListId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            PriceListItemId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ProductId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ProductOptionId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            RelatedItemId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ServiceLocationId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            ShipToAccountId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            SummaryGroupId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            TaxCodeId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account"),
            TransferPriceLineItemId = new LookupObject("698a4234-979b-4780-8553-899fb1fcab88", "Test Account")
        };

        lines.Add(lineItemObj);
    }

    return lines;
}


public class Agreement
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class MP_LineItem_300 : BaseObject
{
    public LookupObject cartId { get; set; }
    public string CurrencyIsoCode { get; set; }
    public LookupObject ConfigurationId { get; set; }
    public LookupObject AdHocGroupId { get; set; }
    public string AddedByRuleInfo { get; set; }
    public string AddedBy { get; set; }
    public decimal? AdjustedPrice { get; set; }
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
    public decimal? BaseCostOverride { get; set; }
    public decimal? BaseCost { get; set; }
    public decimal? BaseExtendedCost { get; set; }
    public decimal? BaseExtendedPrice { get; set; }
    public string BasePriceMethod { get; set; }
    public decimal? BasePriceOverride { get; set; }
    public decimal? BasePrice { get; set; }
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
    public decimal? Cost { get; set; }
    public string CouponCode { get; set; }
    public bool? Customizable { get; set; }
    public decimal? DeltaPrice { get; set; }
    public decimal? DeltaQuantity { get; set; }
    public LookupObject DerivedFromId { get; set; }
    public string Description { get; set; }
    public string EndDate { get; set; }
    public decimal? ExtendedCost { get; set; }
    public string ExtendedDescription { get; set; }
    public decimal? ExtendedPrice { get; set; }
    public decimal? ExtendedQuantity { get; set; }
    public decimal? FlatOptionPrice { get; set; }
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
    public decimal? IncentiveAdjustmentAmount { get; set; }
    public decimal? IncentiveBasePrice { get; set; }
    public string IncentiveCode { get; set; }
    public decimal? IncentiveExtendedPrice { get; set; }
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
    public decimal? ListPrice { get; set; }
    public LookupObject LocationId { get; set; }
    public decimal? MaxPrice { get; set; }
    public decimal? MaxUsageQuantity { get; set; }
    public string MinMaxPriceAppliesTo { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MinUsageQuantity { get; set; }
    public string NetAdjustmentPercent { get; set; } //decimal? 
    public decimal? NetPrice { get; set; }
    public decimal? NetUnitPrice { get; set; }
    public decimal? OptionCost { get; set; }
    public string OptionGroupLabel { get; set; }
    public LookupObject OptionId { get; set; }
    public decimal? OptionPrice { get; set; }
    public decimal? OptionSequence { get; set; }
    public LookupObject OrderLineItemId { get; set; }
    public string OrderLineStatus { get; set; }
    public decimal? ParentBundleNumber { get; set; }
    public LookupObject PaymentTermId { get; set; }
    public decimal? PriceAdjustmentAmount { get; set; }
    public string PriceAdjustmentAppliesTo { get; set; }
    public string PriceAdjustmentType { get; set; }
    public decimal? PriceAdjustment { get; set; }
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
    public decimal? RelatedPercent { get; set; }
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
    public decimal? UnitCostAdjustment { get; set; }
    public decimal? UnitPriceAdjustmentAuto { get; set; }
    public decimal? UnitPriceAdjustmentManual { get; set; }
    public string Uom { get; set; }
    public string Apttus_CQApprov__Approval_Status { get; set; }
    public string ibmcBillingCodeTxt { get; set; }
    public string ibmcRealServiceFeatureCdTxt { get; set; }
    public string ibmcPriceReferenceDate { get; set; }
    public string ibmcprerequisiteProductId { get; set; }
    public string IBMC_Approval_Key { get; set; }
    public decimal? IBMC_Extended_List_Price { get; set; }
    public string IBMC_Financial_Approval_Key { get; set; }
    public string Product_Name { get; set; }
    public decimal? SellCostPct { get; set; }
    public LookupObject ibmcAccountFilterId { get; set; }
    public string ibmcAllowedServiceFeatureCd { get; set; }
    public string ibmcAllowedServices { get; set; }
    public decimal? ibmcAnnualListPriceAmt { get; set; }
    public decimal? ibmcApprovalLevel { get; set; }
    public bool? ibmcApprovalRequiredInd { get; set; }
    public string ibmcAssetDescTxt { get; set; }
    public decimal? ibmcBPNetPriceAmt { get; set; }
    public decimal? ibmcBasePriceAmt { get; set; }
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
    public decimal? ibmcNetGPNum { get; set; }
    public decimal? ibmcNetGPPct { get; set; }
    public decimal? ibmcNetPriceAmt { get; set; }
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
    public decimal? ibmcYear1BPNetPriceAmt { get; set; }
    public decimal? ibmcYearOneListPriceAmt { get; set; }
    public decimal? ibmcYearOneNetPriceAmt { get; set; }
    public decimal? ibmc_bpExhibitDiscountPct { get; set; }
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
    public decimal? ibmcExtendedAnnualListPrice { get; set; }
    public string ibmcCurrencyExchangeRateVersion { get; set; }
    public decimal? ibmcCurrencyExchangeRate { get; set; }
    public string ibmcFinDivisionCd { get; set; }
    public decimal? Net_Price_without_Fees { get; set; }
    public string ibmcApproval_type { get; set; }
    public decimal? ibmcBPNetPrice_withVATAmt { get; set; }
    public bool? ibmcLineManuallyDeleted { get; set; }
    public decimal? ibmcNetGPwithoutFees { get; set; }
    public decimal? ibmcNetPrice_withVATAmt { get; set; }
    public string ibmcTransactionID { get; set; }
    public decimal? ibmcVATAmountAmt { get; set; }
    public decimal? ibmcVATPct { get; set; }
    public decimal? ibmcVolumeDisc { get; set; }
    public decimal? ibmcYear1NetPrice_withVATAmt { get; set; }
    public decimal? ibmcYear1_BPNetPrice_withVATAmt { get; set; }
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
    public decimal? ibmcOldNetPrice { get; set; }
    public string ibmcApprovalKey2 { get; set; }
    public string ibmcCOLABaseDate { get; set; }
    public decimal? ibmcCOLABaseIndex { get; set; }
    public string ibmcCOLACurrentIndexDate { get; set; }
}

#endregion

