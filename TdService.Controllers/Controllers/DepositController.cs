namespace TdService.UI.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using System.Xml;
    using PayPal.Manager;
    using PayPal.PayPalAPIInterfaceService;
    using PayPal.PayPalAPIInterfaceService.Model;
    using TdService.Infrastructure.Authentication;

    public class DepositController : BaseAuthController
    {
        public DepositController(IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {

        }

        /// <summary>
        /// The default page.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Calls the paypal API to get authorization token, then redirects to PP site
        /// </summary>
        /// <returns>
        /// Get transaction history in JSON formatted result.
        /// </returns>
        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult RedirectToPayPal(decimal amount)
        {
            // Create request object
            var request = new SetExpressCheckoutRequestType();

            var ecDetails = new SetExpressCheckoutRequestDetailsType();
            ecDetails.ReturnURL = ResolveServerUrl(VirtualPathUtility.ToAbsolute(Url.Action("Dashboard","Member")),false);
            ecDetails.CancelURL = ResolveServerUrl(VirtualPathUtility.ToAbsolute(Url.Action("DepositCanceled","Member")),false);

            var paymentDetails = new PaymentDetailsType();
            ecDetails.PaymentDetails.Add(paymentDetails);
            paymentDetails.OrderDescription = "SAW sandbox test deposit";
            paymentDetails.PaymentAction = PaymentActionCodeType.SALE;
            var currency = CurrencyCodeType.USD;
            paymentDetails.ItemTotal = new BasicAmountType(currency, amount.ToString());
            paymentDetails.OrderTotal = new BasicAmountType(currency, amount.ToString());
            paymentDetails.SellerDetails = new SellerDetailsType() { SellerUserName = "SAW" };
            request.SetExpressCheckoutRequestDetails = ecDetails;

            // Invoke the API
            SetExpressCheckoutReq wrapper = new SetExpressCheckoutReq();
            wrapper.SetExpressCheckoutRequest = request;
            PayPalAPIInterfaceServiceService service = new PayPalAPIInterfaceServiceService();
            SetExpressCheckoutResponseType setECResponse = service.SetExpressCheckout(wrapper);

            if (setECResponse.Ack==AckCodeType.SUCCESS)
            {
                var ppUrl = ConfigManager.Instance.GetProperty("paypalUrl") + "_express-checkout&token=" + setECResponse.Token;
                var jsonNetResult = new JsonNetResult
                {
                    Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                    Data = ppUrl
                };
                return jsonNetResult;
            }
            //TODO: handle errors
            return null;
        }

        [Authorize(Roles = "Shopper")]
        [HttpPost]
        public ActionResult ConfirmExpressCheckOutPayment(string token, string payerId)
        {
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

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = "success"
            };
            //TODO: handle errors
            return jsonNetResult;
        }

        private static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;

            string newUrl = serverUrl;
            Uri originalUri = System.Web.HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                "://" + originalUri.Authority + newUrl;
            return newUrl;
        }


       
    }
}
