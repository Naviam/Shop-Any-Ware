// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntlRateV2Response.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The intl rate v 2 response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Shipping
{
    using System.Xml.Serialization;

    /// <summary>
    /// The intl rate v 2 response.
    /// </summary>
    public class IntlRateV2Response
    {
        /// <summary>
        /// Gets or sets the packages.
        /// </summary>
        [XmlArray(ElementName = "Package")]
        public Package Packages { get; set; }

        /// <summary>
        /// The package.
        /// </summary>
        public class Package
        {
            /// <summary>
            /// Gets or sets the id.
            /// </summary>
            [XmlAttribute(AttributeName = "ID")]
            public string Id { get; set; }

            /// <summary>
            /// Gets or sets the prohibitions.
            /// </summary>
            public string Prohibitions { get; set; }

            /// <summary>
            /// Gets or sets the restrictions.
            /// </summary>
            public string Restrictions { get; set; }

            /// <summary>
            /// Gets or sets the observations.
            /// </summary>
            public string Observations { get; set; }

            /// <summary>
            /// Gets or sets the customs forms.
            /// </summary>
            public string CustomsForms { get; set; }

            /// <summary>
            /// Gets or sets the express mail.
            /// </summary>
            public string ExpressMail { get; set; }

            /// <summary>
            /// Gets or sets the areas served.
            /// </summary>
            public string AreasServed { get; set; }

            /// <summary>
            /// Gets or sets the additional restrictions.
            /// </summary>
            public string AdditionalRestrictions { get; set; }

            /// <summary>
            /// The service.
            /// </summary>
            public class Service
            {
            }
        }
    }
}