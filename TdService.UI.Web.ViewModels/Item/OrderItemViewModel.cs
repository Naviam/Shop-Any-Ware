// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderItemViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The order item view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Item
{
    /// <summary>
    /// The order item view model.
    /// </summary>
    public class OrderItemViewModel : ItemViewModel
    {
        /// <summary>
        /// Gets or sets the order id.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// specifies whether page is viewed by operator or admin
        /// </summary>
        public bool OperatorMode { get; set; }
    }
}