// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterClientValidationExtensions.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the RegisterClientValidationExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(TdService.UI.Web.MVC.App_Start.RegisterClientValidationExtensions), "Start")]

namespace TdService.UI.Web.MVC.App_Start
{
    /// <summary>
    /// The register client validation extensions.
    /// </summary>
    public static class RegisterClientValidationExtensions
    {
        /// <summary>
        /// Register validation providers.
        /// </summary>
        public static void Start()
        {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();
        }
    }
}