using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayPal.Manager;
using PayPal.PayPalAPIInterfaceService;
using PayPal.PayPalAPIInterfaceService.Model;

namespace TdService.Infrastructure.PayPalHelpers
{
    public class PayPalHelper
    {
        /// <summary>
        /// sets the express checout and return token for  further redirect
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="successUrl"></param>
        /// <param name="cancelUrl"></param>
        /// <param name="orderDescription"></param>
        /// <param name="sellerUserName"></param>
        /// <returns></returns>
        public static string GetTokenFromPayPalApi(decimal amount, string successUrl, string cancelUrl, string orderDescription, string sellerUserName)
        {
            // Create request object
            var request = new SetExpressCheckoutRequestType();

            var ecDetails = new SetExpressCheckoutRequestDetailsType();
            ecDetails.ReturnURL = successUrl;
            ecDetails.CancelURL = cancelUrl;

            var paymentDetails = new PaymentDetailsType();
            ecDetails.PaymentDetails.Add(paymentDetails);
            paymentDetails.OrderDescription = orderDescription;
            paymentDetails.PaymentAction = PaymentActionCodeType.SALE;
            var currency = CurrencyCodeType.USD;//TODO: changeable?
            paymentDetails.ItemTotal = new BasicAmountType(currency, amount.ToString());
            paymentDetails.OrderTotal = new BasicAmountType(currency, amount.ToString());
            paymentDetails.SellerDetails = new SellerDetailsType() { SellerUserName = sellerUserName};
            request.SetExpressCheckoutRequestDetails = ecDetails;

            // Invoke the API
            SetExpressCheckoutReq wrapper = new SetExpressCheckoutReq();
            wrapper.SetExpressCheckoutRequest = request;
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
            SetExpressCheckoutResponseType setECResponse = service.SetExpressCheckout(wrapper);

            if (setECResponse.Ack == AckCodeType.SUCCESS)
            {
                return setECResponse.Token;
            }

            throw new PayPalException(setECResponse.Errors);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string GetRedirectUrl(string token)
        {
            var result = ConfigManager.Instance.GetProperty("paypalUrl") + "_express-checkout&token=" + token;
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="payerId"></param>
        public static void ConfirmPayPalPayment(string token, string payerId)
        {
            //confirm deposit
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
            GetExpressCheckoutDetailsReq getECWrapper = new GetExpressCheckoutDetailsReq();
            getECWrapper.GetExpressCheckoutDetailsRequest = new GetExpressCheckoutDetailsRequestType(token);
            GetExpressCheckoutDetailsResponseType getECResponse = service.GetExpressCheckoutDetails(getECWrapper);

            // Create request object
            DoExpressCheckoutPaymentRequestType request = new DoExpressCheckoutPaymentRequestType();
            DoExpressCheckoutPaymentRequestDetailsType requestDetails = new DoExpressCheckoutPaymentRequestDetailsType();
            request.DoExpressCheckoutPaymentRequestDetails = requestDetails;

            requestDetails.PaymentDetails = getECResponse.GetExpressCheckoutDetailsResponseDetails.PaymentDetails;
            requestDetails.Token = token;
            requestDetails.PayerID = payerId;
            requestDetails.PaymentAction = PaymentActionCodeType.SALE;

            // Invoke the API
            DoExpressCheckoutPaymentReq wrapper = new DoExpressCheckoutPaymentReq();
            wrapper.DoExpressCheckoutPaymentRequest = request;
            DoExpressCheckoutPaymentResponseType doECResponse = service.DoExpressCheckoutPayment(wrapper);
            if (doECResponse.Ack== AckCodeType.SUCCESS)
            {
                return;
            }
            throw new PayPalException(doECResponse.Errors);
        }
    }
}
