// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RetailerViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The retailer view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.ViewModels.Retailer
{
    /// <summary>
    /// The retailer view model.
    /// </summary>
    public class RetailerViewModel : BaseView
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }
    }
}