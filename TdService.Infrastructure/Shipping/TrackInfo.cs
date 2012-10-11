// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackInfo.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The track info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Shipping
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    /// <summary>
    /// The track info.
    /// </summary>
    public class TrackInfo
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlAttribute("ID")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the summary.
        /// </summary>
        [XmlElement("TrackSummary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        public List<string> Details { get; set; }
    }
}