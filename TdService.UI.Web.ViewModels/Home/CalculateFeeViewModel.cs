// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CalculateFeeViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The calculate fee view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Home
{
    /// <summary>
    /// The calculate fee view model.
    /// </summary>
    public class CalculateFeeViewModel
    {
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public int Weight { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        public decimal Length { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public decimal Width { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        public decimal Height { get; set; }

        /// <summary>
        /// Gets or sets the girth.
        /// </summary>
        public decimal Girth { get; set; }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the country name.
        /// </summary>
        public string CountryName { get; set; }

        /// <summary>
        /// Gets or sets the delivery method id.
        /// </summary>
        public int DeliveryMethodId { get; set; }
    }
}
