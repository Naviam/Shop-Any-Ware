// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCountriesResponse.cs" company="Naviam">
//   Vadim  Shaporov. 2013
// </copyright>
// <summary>
//   The get countries response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Address
{
    /// <summary>
    /// The get countries response.
    /// </summary>
    public class GetCountriesResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the translated name.
        /// </summary>
        public string TranslatedName { get; set; }

        /// <summary>
        /// Gets or sets the default name.
        /// </summary>
        public string DefaultName { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public string Code { get; set; }
    }
}
