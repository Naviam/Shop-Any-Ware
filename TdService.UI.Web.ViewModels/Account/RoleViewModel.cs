// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoleViewModel.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The role view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using TdService.Resources;

    /// <summary>
    /// The role view model.
    /// </summary>
    public class RoleViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the translated status
        /// </summary>
        public string NameTranslated
        {
            get
            {
                return !string.IsNullOrWhiteSpace(this.Name) ? RoleNamesResources.ResourceManager.GetString(this.Name) : string.Empty;
            }
        }
    }
}
