// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The item view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Item
{
    /// <summary>
    /// The item view model.
    /// </summary>
    public class ItemViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }
    }
}