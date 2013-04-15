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
    using TdService.Resources;

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
        /// Gets the translated name.
        /// </summary>
        public string TranslatedName
        {
            get
            {
                return Countries.ResourceManager.GetString(this.Code);
            }
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the default name.
        /// </summary>
        public string DefaultName { get; set; }
    }
}