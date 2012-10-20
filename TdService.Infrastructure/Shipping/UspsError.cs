// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UspsError.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The usps error.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Shipping
{
    using System.Xml.Serialization;

    /// <summary>
    /// The USPS error.
    /// </summary>
    [XmlRoot(ElementName = "Error")]
    public class UspsError
    {
        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the help file.
        /// </summary>
        public string HelpFile { get; set; }

        /// <summary>
        /// Gets or sets the help context.
        /// </summary>
        public string HelpContext { get; set; }
    }
}
