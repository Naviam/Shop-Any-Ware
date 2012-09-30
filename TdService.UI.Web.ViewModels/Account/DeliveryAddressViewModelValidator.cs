// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryAddressViewModelValidator.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The delivery address view model validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using FluentValidation;

    using TdService.Infrastructure.Domain;
    using TdService.Resources;

    /// <summary>
    /// The delivery address view model validator.
    /// </summary>
    public class DeliveryAddressViewModelValidator : AbstractValidator<DeliveryAddressViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeliveryAddressViewModelValidator"/> class.
        /// </summary>
        public DeliveryAddressViewModelValidator()
        {
            // First set the cascade mode
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(da => da.AddressName)
                .NotEmpty().WithState(e => ErrorCode.DeliveryAddressAddressNameRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressAddressNameRequired)
                .Length(1, 40).WithState(e => ErrorCode.DeliveryAddressAddressNameMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressAddressNameMaxLength);
            RuleFor(da => da.FirstName)
                .NotEmpty().WithState(e => ErrorCode.DeliveryAddressFirstNameRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressFirstNameRequired)
                .Length(1, 21).WithState(e => ErrorCode.DeliveryAddressFirstNameMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressFirstNameMaxLength);
            RuleFor(da => da.LastName)
                .NotEmpty().WithState(e => ErrorCode.DeliveryAddressLastNameRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressLastNameRequired)
                .Length(1, 21).WithState(e => ErrorCode.DeliveryAddressLastNameMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressLastNameMaxLength);

            RuleFor(da => da.AddressLine1)
                .NotEmpty().WithState(e => ErrorCode.AddressAddressLine1Required.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressAddressLine1Required)
                .Length(1, 256).WithState(e => ErrorCode.AddressAddressLine1MaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressAddressLine1MaxLength);
            RuleFor(da => da.AddressLine2)
                .Length(0, 256).WithState(e => ErrorCode.AddressAddressLine2MaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressAddressLine2MaxLength);
            RuleFor(da => da.State)
                .Length(0, 64).WithState(e => ErrorCode.AddressStateMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressStateMaxLength);
            RuleFor(da => da.Region)
                .Length(0, 64).WithState(e => ErrorCode.AddressRegionMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressRegionMaxLength);
            RuleFor(da => da.City)
                .NotEmpty().WithState(e => ErrorCode.AddressCityRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressCityRequired)
                .Length(1, 64).WithState(e => ErrorCode.AddressCityMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressCityMaxLength);
            RuleFor(da => da.Country)
                .NotEmpty().WithState(e => ErrorCode.AddressCountryRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressCountryRequired)
                .Length(1, 64).WithState(e => ErrorCode.AddressCountryMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressCountryMaxLength);
            RuleFor(da => da.ZipCode)
                .NotEmpty().WithState(e => ErrorCode.AddressZipCodeRequired.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressZipCodeRequired)
                .Length(1, 10).WithState(e => ErrorCode.AddressZipCodeMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressZipCodeMaxLength);
            RuleFor(da => da.Phone)
                .Length(0, 21).WithState(e => ErrorCode.AddressPhoneMaxLength.ToString()).WithLocalizedMessage(() => ErrorCodeResources.AddressPhoneMaxLength);
        }
    }
}