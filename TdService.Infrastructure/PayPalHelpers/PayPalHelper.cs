// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayPalHelper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The pay pal helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.PayPalHelpers
{
    using System.Globalization;

    using PayPal.Manager;
    using PayPal.PayPalAPIInterfaceService;
    using PayPal.PayPalAPIInterfaceService.Model;

    /// <summary>
    /// The pay pal helper.
    /// </summary>
    public class PayPalHelper
    {
        /// <summary>
        /// The get token from pay pal API.
        /// </summary>
        /// <param name="amount">
        /// The amount.
        /// </param>
        /// <param name="successUrl">
        /// The success url.
        /// </param>
        /// <param name="cancelUrl">
        /// The cancel url.
        /// </param>
        /// <param name="orderDescription">
        /// The order description.
        /// </param>
        /// <param name="sellerUserName">
        /// The seller user name.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="PayPalException">
        /// Pay pal exception.
        /// </exception>
        public static string GetTokenFromPayPalApi(decimal amount, string successUrl, string cancelUrl, string orderDescription, string sellerUserName)
        {
            // Create request object
            var request = new SetExpressCheckoutRequestType();

            var details = new SetExpressCheckoutRequestDetailsType { ReturnURL = successUrl, CancelURL = cancelUrl };

            var paymentDetails = new PaymentDetailsType();
            details.PaymentDetails.Add(paymentDetails);
            paymentDetails.OrderDescription = orderDescription;
            paymentDetails.PaymentAction = PaymentActionCodeType.SALE;
            const CurrencyCodeType Currency = CurrencyCodeType.USD; // TODO: changeable?
            paymentDetails.ItemTotal = new BasicAmountType(Currency, amount.ToString(CultureInfo.InvariantCulture));
            paymentDetails.OrderTotal = new BasicAmountType(Currency, amount.ToString(CultureInfo.InvariantCulture));
            paymentDetails.SellerDetails = new SellerDetailsType { SellerUserName = sellerUserName };
            request.SetExpressCheckoutRequestDetails = details;

            // Invoke the API
            var wrapper = new SetExpressCheckoutReq { SetExpressCheckoutRequest = request };
            var service = new PayPalAPIInterfaceServiceService();
            var setEcResponse = service.SetExpressCheckout(wrapper);

            if (setEcResponse.Ack == AckCodeType.SUCCESS)
            {
                return setEcResponse.Token;
            }

            throw new PayPalException(setEcResponse.Errors);
        }

        /// <summary>
        /// The get redirect url.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetRedirectUrl(string token)
        {
            var result = ConfigManager.Instance.GetProperty("paypalUrl") + "_express-checkout&token=" + token;
            return result;
        }

        /// <summary>
        /// The confirm pay pal payment.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        /// <param name="payerId">
        /// The payer id.
        /// </param>
        /// <exception cref="PayPalException">
        /// Pay pal exception.
        /// </exception>
        public static void ConfirmPayPalPayment(string token, string payerId)
        {
            // confirm deposit
            var service = new PayPalAPIInterfaceServiceService();
            var getEcWrapper = new GetExpressCheckoutDetailsReq
                                   {
                                       GetExpressCheckoutDetailsRequest =
                                           new GetExpressCheckoutDetailsRequestType(token)
                                   };
            var getEcResponse = service.GetExpressCheckoutDetails(getEcWrapper);

            // Create request object
            var request = new DoExpressCheckoutPaymentRequestType();
            var requestDetails = new DoExpressCheckoutPaymentRequestDetailsType();
            request.DoExpressCheckoutPaymentRequestDetails = requestDetails;

            requestDetails.PaymentDetails = getEcResponse.GetExpressCheckoutDetailsResponseDetails.PaymentDetails;
            requestDetails.Token = token;
            requestDetails.PayerID = payerId;
            requestDetails.PaymentAction = PaymentActionCodeType.SALE;

            // Invoke the API
            var wrapper = new DoExpressCheckoutPaymentReq { DoExpressCheckoutPaymentRequest = request };
            var doEcResponse = service.DoExpressCheckoutPayment(wrapper);
            if (doEcResponse.Ack == AckCodeType.SUCCESS)
            {
                return;
            }

            throw new PayPalException(doEcResponse.Errors);
        }
    }
}