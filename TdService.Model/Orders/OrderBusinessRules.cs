// -----------------------------------------------------------------------
// <copyright file="OrderBusinessRules.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The order business rules.
    /// </summary>
    public static class OrderBusinessRules
    {
        /// <summary>
        /// This rule ensures that retailer is set.
        /// </summary>
        public static readonly BusinessRule RetailerRequired =
            new BusinessRule("Retailer", ErrorCode.OrderRetailerRequired.ToString());

        /// <summary>
        /// This rule ensures that created date is set.
        /// </summary>
        public static readonly BusinessRule CreatedDateRequired =
            new BusinessRule("CreatedDate", ErrorCode.OrderCreatedDateRequired.ToString());

        /// <summary>
        /// This rule ensures that received date is set.
        /// </summary>
        public static readonly BusinessRule ReceivedDateRequired =
            new BusinessRule("ReceivedDate", ErrorCode.OrderReceivedDateRequired.ToString());

        /// <summary>
        /// This rule ensures that weight is set.
        /// </summary>
        public static readonly BusinessRule WeightRequired =
            new BusinessRule("Weight", ErrorCode.OrderWeightRequired.ToString());

        /// <summary>
        /// This rule ensures that order number is withing max length.
        /// </summary>
        public static readonly BusinessRule OrderNumberLength =
            new BusinessRule("OrderNumber", ErrorCode.OrderOrderNumberMaxLength.ToString());

        /// <summary>
        /// This rule ensures that tracking number is withing max length.
        /// </summary>
        public static readonly BusinessRule TrackingNumberLength =
            new BusinessRule("TrackingNumber", ErrorCode.OrderTrackingNumberMaxLength.ToString());

        /// <summary>
        /// This rule ensures that extended status is withing max length.
        /// </summary>
        public static readonly BusinessRule StatusExtendedLength =
            new BusinessRule("StatusExtended", ErrorCode.OrderStatusExtendedMaxLength.ToString());
    }
}