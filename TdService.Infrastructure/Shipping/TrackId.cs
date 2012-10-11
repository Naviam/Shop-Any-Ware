// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackId.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The track ID.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Shipping
{
    using System.Xml.Serialization;

    /// <summary>
    /// The track ID.
    /// </summary>
    public class TrackId
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [XmlAttribute(AttributeName = "ID")]
        public string Id { get; set; }
    }
}