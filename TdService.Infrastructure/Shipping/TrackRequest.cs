// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrackRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The track request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Shipping
{
    using System.Xml.Serialization;

    /// <summary>
    /// The track request.
    /// </summary>
    [XmlRoot(ElementName = "TrackRequest")]
    public class TrackRequest
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [XmlAttribute(AttributeName = "USERID")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the tracking number.
        /// </summary>
        [XmlElement(ElementName = "TrackID")]
        public TrackId TrackingNumber { get; set; }
    }
}