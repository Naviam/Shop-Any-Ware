// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Home controller contains methods to display pages for unregistered shoppers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.Controllers
{
    using System.Web.Mvc;
    using System.Xml;
    using System.Linq;

    using TdService.Infrastructure.CookieStorage;
    using TdService.Infrastructure.Usps;
    using TdService.Services.Interfaces;
    using TdService.UI.Web.Controllers.Base;
    using TdService.UI.Web.Mapping;
    using TdService.UI.Web.ViewModels.Account;
    using TdService.UI.Web.ViewModels.Home;

    /// <summary>
    /// Home controller contains methods to display pages for unregistered shoppers.
    /// </summary>
    public class HomeController : BaseController
    {
        /// <summary>
        /// The address Service.
        /// </summary>
        private readonly IAddressService addressService;

        /// <summary>
        /// The cookie storage service.
        /// </summary>
        private readonly ICookieStorageService cookieStorageService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="addressService">
        /// The address service.
        /// </param>
        /// <param name="cookieStorageService">
        /// The cookie Storage Service.
        /// </param>
        public HomeController(IAddressService addressService, ICookieStorageService cookieStorageService)
        {
            this.addressService = addressService;
            this.cookieStorageService = cookieStorageService;
        }

        /// <summary>
        /// The default page.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            var signInViewModel = new SignInViewModel();
            this.SetCredentialsFromCookie(ref signInViewModel);

            var model = new MainViewModel { SignInViewModel = signInViewModel, SignUpViewModel = new SignUpViewModel() };
            return this.View(model);
        }

        /// <summary>
        /// The page contains information about online US retailers.
        /// </summary>
        /// <returns>
        /// Returns view with the catalog of online US retailers.
        /// </returns>
        public ActionResult Shops()
        {
            return this.View();
        }

        /// <summary>
        /// The page with price information for the service.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Services()
        {
            return this.View();
        }

        /// <summary>
        /// The page contains information about terms and conditions of using this service.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Terms()
        {
            return this.View();
        }

        /// <summary>
        /// The page contains help information for new users to get started quickly.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Help()
        {
            return this.View();
        }

        /// <summary>
        /// The page contains contact information.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Contact()
        {
            return this.View();
        }

        /// <summary>
        /// The page contains about us information.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult About()
        {
            return this.View();
        }

        /// <summary>
        /// The rate.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Rate()
        {
            return this.View();
        }

        /// <summary>
        /// The get countries.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult GetCountries()
        {
            var result = this.addressService.GetCountries().ConvertToCountriesViewModel();

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = result
            };
            return jsonNetResult;
        }

        /// <summary>
        /// The calculate rate.
        /// </summary>
        /// <param name="model">
        /// The model.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        [HttpPost]
        public ActionResult CalculateRate(CalculateFeeViewModel model)
        {
            var rates = UspsRateCalculator.GetShippingRates(
                model.Weight, 15, 15, 15, 0, model.CountryName, "150");

            var jsonNetResult = new JsonNetResult
            {
                Formatting = (Formatting)Newtonsoft.Json.Formatting.Indented,
                Data = new
                           {
                               Rate = model.DeliveryMethodId == 1 ? rates.ExpressMailPostagePrice : rates.PriorityMailPostagePrice,
                               rates.Error
                           }
            };
            return jsonNetResult;
        }

        /// <summary>
        /// Set credentials from cookie to sign in view.
        /// </summary>
        /// <param name="view">
        /// The view.
        /// </param>
        private void SetCredentialsFromCookie(ref SignInViewModel view)
        {
            var values = this.cookieStorageService.RetrieveCollection("shopanyware_login");
            if (values != null)
            {
                view.Email = values["Email"];
                ////view.Password = values["Password"];
                view.RememberMe = values["RememberMe"] == "yes";
            }
        }
    }
}