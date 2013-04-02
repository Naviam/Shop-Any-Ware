// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorCode.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The domain errors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The domain errors.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.")]
    public enum ErrorCode
    {
        UserEmailExists,
        UserEmailInvalid,
        UserEmailMaxLength,
        UserEmailRequired,
        UserNotValid,
        UserNotFound,
        UserPasswordMaxLength,
        UserPasswordMinLength,
        UserPasswordRequired,
        UserPasswordConfirmRequired,
        UserPasswordConfirmNotEqual,
        RoleDescriptionMaxLength,
        RoleNameMaxLength,
        RoleNameRequired,
        ProfileFirstNameMaxLength,
        ProfileFirstNameRequired,
        ProfileLastNameMaxLength,
        ProfileLastNameRequired,
        ProfileNotFound,
        AddressAddressLine1MaxLength,
        AddressAddressLine1Required,
        AddressAddressLine2MaxLength,
        AddressCityMaxLength,
        AddressCityRequired,
        AddressCountryMaxLength,
        AddressCountryRequired,
        AddressZipCodeMaxLength,
        AddressZipCodeRequired,
        AddressPhoneMaxLength,
        AddressRegionMaxLength,
        AddressStateMaxLength,
        DeliveryAddressAddressNameMaxLength,
        DeliveryAddressAddressNameRequired,
        DeliveryAddressFirstNameMaxLength,
        DeliveryAddressFirstNameRequired,
        DeliveryAddressLastNameMaxLength,
        DeliveryAddressLastNameRequired,
        OrderCreatedDateRequired,
        OrderOrderNumberMaxLength,
        OrderReceivedDateRequired,
        OrderRetailerRequired,
        OrderStatusRequired,
        OrderStatusExtendedMaxLength,
        OrderTrackingNumberMaxLength,
        OrderWeightRequired,
        OrderNotFoundForUser,
        OrderCannotBeAddedByYou,
        OrderCannotBeUpdated,
        OrderCannotBeRemoved,
        PackageNameMaxLength,
        PackageNameRequired,
        PackageCannotBeAddedByYou,
        ItemNameMaxLength,
        ItemNameRequired,
        ItemPriceRequired,
        ItemQuantityRequired,
        ItemWeightRequired,
        CourierNameMaxLength,
        CourierNameRequired,
        RetailerCategoryMaxLength,
        RetailerCategoryRequired,
        RetailerDescriptionMaxLength,
        RetailerNameMaxLength,
        RetailerNameRequired,
        RetailerUrlMaxLength,
        RetailerUrlRequired,
        UserPasswordLength,
        TransactionOperationAmountRequired,
        UserIsAlreadyInRole,
        UserIsNotInRole,
        NoRolesSpecified,
        WalletAmountNegative
    }
}