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

            RuleFor(da => da.AddressName).NotEmpty().WithMessage(ErrorCode.DeliveryAddressAddressNameRequired.ToString())
                .Length(1, 40).WithMessage(ErrorCode.DeliveryAddressAddressNameMaxLength.ToString());
            RuleFor(da => da.FirstName).NotEmpty().WithMessage(ErrorCode.DeliveryAddressFirstNameRequired.ToString())
                .Length(1, 21).WithMessage(ErrorCode.DeliveryAddressFirstNameMaxLength.ToString());
            RuleFor(da => da.LastName).NotEmpty().WithMessage(ErrorCode.DeliveryAddressLastNameRequired.ToString())
                .Length(1, 21).WithMessage(ErrorCode.DeliveryAddressLastNameMaxLength.ToString());

            RuleFor(da => da.AddressLine1).NotEmpty().WithMessage(ErrorCode.AddressAddressLine1Required.ToString())
                .Length(1, 256).WithMessage(ErrorCode.AddressAddressLine1MaxLength.ToString());
            RuleFor(da => da.AddressLine2).Length(0, 256).WithMessage(ErrorCode.AddressAddressLine2MaxLength.ToString());
            RuleFor(da => da.State).Length(0, 64).WithMessage(ErrorCode.AddressStateMaxLength.ToString());
            RuleFor(da => da.Region).Length(0, 64).WithMessage(ErrorCode.AddressRegionMaxLength.ToString());
            RuleFor(da => da.City).NotEmpty().WithMessage(ErrorCode.AddressCityRequired.ToString())
                .Length(1, 64).WithMessage(ErrorCode.AddressCityMaxLength.ToString());
            RuleFor(da => da.Country).NotEmpty().WithMessage(ErrorCode.AddressCountryRequired.ToString())
                .Length(1, 64).WithMessage(ErrorCode.AddressCountryMaxLength.ToString());
            RuleFor(da => da.ZipCode).NotEmpty().WithMessage(ErrorCode.AddressZipCodeRequired.ToString())
                .Length(1, 10).WithMessage(ErrorCode.AddressZipCodeMaxLength.ToString());
            RuleFor(da => da.Phone).Length(0, 21).WithMessage(ErrorCode.AddressPhoneMaxLength.ToString());
        }
    }
}