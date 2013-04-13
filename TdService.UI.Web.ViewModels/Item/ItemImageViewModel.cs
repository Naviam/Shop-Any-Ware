// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemImageViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The item image view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Item
{
    /// <summary>
    /// The item image view model.
    /// </summary>
    public class ItemImageViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        public int ItemId { get; set; }
    }
}