// -----------------------------------------------------------------------
// <copyright file="OrderBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// The order business rules.
    /// </summary>
    public static class OrderBusinessRules
    {
        /// <summary>
        /// This rule ensures that retailer is set.
        /// </summary>
        public static readonly BusinessRule RetailerRequired =
            new BusinessRule("Retailer", BusinessRules.Order_RetailerRequired);

        /// <summary>
        /// This rule ensures that created date is set.
        /// </summary>
        public static readonly BusinessRule CreatedDateRequired =
            new BusinessRule("CreatedDate", BusinessRules.Order_CreatedDateRequired);

        /// <summary>
        /// This rule ensures that received date is set.
        /// </summary>
        public static readonly BusinessRule ReceivedDateRequired =
            new BusinessRule("ReceivedDate", BusinessRules.Order_ReceivedDateRequired);

        /// <summary>
        /// This rule ensures that weight is set.
        /// </summary>
        public static readonly BusinessRule WeightRequired =
            new BusinessRule("Weight", BusinessRules.Order_WeightRequired);

        /// <summary>
        /// This rule ensures that order number is withing max length.
        /// </summary>
        public static readonly BusinessRule OrderNumberLength =
            new BusinessRule("OrderNumber", BusinessRules.Order_OrderNumberLength);

        /// <summary>
        /// This rule ensures that tracking number is withing max length.
        /// </summary>
        public static readonly BusinessRule TrackingNumberLength =
            new BusinessRule("TrackingNumber", BusinessRules.Order_TrackingNumberLength);

        /// <summary>
        /// This rule ensures that extended status is withing max length.
        /// </summary>
        public static readonly BusinessRule StatusExtendedLength =
            new BusinessRule("StatusExtended", BusinessRules.Order_StatusExtendedLength);
    }
}