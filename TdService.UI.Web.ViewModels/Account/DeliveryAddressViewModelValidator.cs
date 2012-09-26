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

            RuleFor(da => da.AddressName).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressAddressNameRequired)
                .Length(1, 40).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressAddressNameMaxLength);
            RuleFor(da => da.FirstName).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressFirstNameRequired)
                .Length(1, 21).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressFirstNameMaxLength);
            RuleFor(da => da.LastName).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressLastNameRequired)
                .Length(1, 21).WithLocalizedMessage(() => ErrorCodeResources.DeliveryAddressLastNameMaxLength);

            RuleFor(da => da.AddressLine1).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.AddressAddressLine1Required)
                .Length(1, 256).WithLocalizedMessage(() => ErrorCodeResources.AddressAddressLine1MaxLength);
            RuleFor(da => da.AddressLine2).Length(0, 256).WithLocalizedMessage(() => ErrorCodeResources.AddressAddressLine2MaxLength);
            RuleFor(da => da.State).Length(0, 64).WithLocalizedMessage(() => ErrorCodeResources.AddressStateMaxLength);
            RuleFor(da => da.Region).Length(0, 64).WithLocalizedMessage(() => ErrorCodeResources.AddressRegionMaxLength);
            RuleFor(da => da.City).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.AddressCityRequired)
                .Length(1, 64).WithLocalizedMessage(() => ErrorCodeResources.AddressCityMaxLength);
            RuleFor(da => da.Country).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.AddressCountryRequired)
                .Length(1, 64).WithLocalizedMessage(() => ErrorCodeResources.AddressCountryMaxLength);
            RuleFor(da => da.ZipCode).NotEmpty().WithLocalizedMessage(() => ErrorCodeResources.AddressZipCodeRequired)
                .Length(1, 10).WithLocalizedMessage(() => ErrorCodeResources.AddressZipCodeMaxLength);
            RuleFor(da => da.Phone).Length(0, 21).WithLocalizedMessage(() => ErrorCodeResources.AddressPhoneMaxLength);
        }
    }
}