// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the AddressController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;

    /// <summary>
    /// The controller contains methods to work with the addresses.
    /// </summary>
    public class AddressController : BaseController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressController"/> class.
        /// </summary>
        /// <param name="formsAuthentication">
        /// The forms authentication.
        /// </param>
        public AddressController(IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
        }

        /// <summary>
        /// Show the list of delivery addresses.
        /// </summary>
        /// <returns>
        /// Returns view with the delivery addresses.
        /// </returns>
        public ActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// Get own warehouse address in USA.
        /// </summary>
        /// <returns>
        /// Returns view with the warehouse address details.
        /// </returns>
        public ActionResult Warehouse()
        {
            return this.View();
        }

        /// <summary>
        /// Get delivery address details.
        /// </summary>
        /// <param name="addressId">
        /// The address Id.
        /// </param>
        /// <returns>
        /// Returns view with delivery address details.
        /// </returns>
        public ActionResult Details(int addressId)
        {
            return this.View();
        }

        /// <summary>
        /// Add delivery address.
        /// </summary>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [HttpPost]
        public ActionResult Create()
        {
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Remove delivery address.
        /// </summary>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [HttpPost]
        public ActionResult Remove()
        {
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Update delivery address.
        /// </summary>
        /// <returns>
        /// Returns view with delivery addresses.
        /// </returns>
        [HttpPost]
        public ActionResult Update()
        {
            return this.RedirectToAction("Index");
        }
    }
}