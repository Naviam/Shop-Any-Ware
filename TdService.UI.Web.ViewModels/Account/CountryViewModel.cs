// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CountryViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The country view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    /// <summary>
    /// The country view model.
    /// </summary>
    public class CountryViewModel
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the translated name.
        /// </summary>
        public string TranslatedName { get; set; }
    }
}