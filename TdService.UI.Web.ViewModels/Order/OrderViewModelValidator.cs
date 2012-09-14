// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderViewModelValidator.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The order view model validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Order
{
    using System;

    using FluentValidation;

    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The order view model validator.
    /// </summary>
    public class OrderViewModelValidator : AbstractValidator<OrderViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderViewModelValidator"/> class.
        /// </summary>
        public OrderViewModelValidator()
        {
            // First set the cascade mode
            this.CascadeMode = CascadeMode.StopOnFirstFailure;

            this.RuleSet(
                "insert",
                () => this.RuleFor(order => order.RetailerUrl)
                    .NotEmpty().WithMessage(ErrorCode.OrderRetailerRequired.ToString())
                    .Length(1, 256).WithMessage(ErrorCode.RetailerUrlMaxLength.ToString()));

            this.RuleSet(
                "update",
                () =>
                    {
                        RuleFor(x => x.Id).NotEqual(0);
                        RuleFor(order => order.OrderNumber).Length(0, 40).WithMessage(ErrorCode.OrderOrderNumberMaxLength.ToString());
                        RuleFor(order => order.TrackingNumber).Length(0, 40).WithMessage(ErrorCode.OrderTrackingNumberMaxLength.ToString());
                    });

            RuleFor(order => order.Status).NotEmpty().WithMessage(ErrorCode.OrderStatusRequired.ToString());
            RuleFor(order => order.RetailerUrl).NotEmpty().WithMessage(ErrorCode.OrderRetailerRequired.ToString())
                            .Length(1, 256).WithMessage(ErrorCode.RetailerUrlMaxLength.ToString());
            RuleFor(order => order.OrderNumber).Length(0, 40).WithMessage(ErrorCode.OrderOrderNumberMaxLength.ToString());
            RuleFor(order => order.TrackingNumber).Length(0, 40).WithMessage(ErrorCode.OrderTrackingNumberMaxLength.ToString());
            RuleFor(order => order.CreatedDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ErrorCode.OrderCreatedDateRequired.ToString());

            this.When(
                order => order.Status == "Received",
                () => this.RuleFor(order => order.ReceivedDate)
                          .LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ErrorCode.OrderReceivedDateRequired.ToString()));
        }
    }
}
