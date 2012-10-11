// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntlRateV2Request.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The intl rate v 2 request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Shipping
{
    using System.Xml.Serialization;

    /// <summary>
    /// The intl rate v 2 request.
    /// </summary>
    public class IntlRateV2Request
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [XmlAttribute(AttributeName = "USERID")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [XmlAttribute(AttributeName = "PASSWORD")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the app id.
        /// </summary>
        [XmlAttribute(AttributeName = "APPID")]
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        [XmlAttribute(AttributeName = "VERSION")]
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the revision.
        /// </summary>
        [XmlElement(ElementName = "Revision")]
        public string Revision { get; set; }

        /// <summary>
        /// The package.
        /// </summary>
        public class Package
        {
            /// <summary>
            /// The mail type.
            /// </summary>
            public enum PackageMailType
            {
                /// <summary>
                /// The all.
                /// </summary>
                All,

                /// <summary>
                /// The package.
                /// </summary>
                Package,

                /// <summary>
                /// The post cards.
                /// </summary>
                PostCards,

                /// <summary>
                /// The envelope.
                /// </summary>
                Envelope,

                /// <summary>
                /// The large envelope.
                /// </summary>
                LargeEnvelope,

                /// <summary>
                /// The flat rate.
                /// </summary>
                FlatRate
            }

            /// <summary>
            /// The container.
            /// </summary>
            public enum PackageContainer
            {
                /// <summary>
                /// The rectangular.
                /// </summary>
                [XmlEnum(Name = "RECTANGULAR")]
                Rectangular,

                /// <summary>
                /// The nonrectangular.
                /// </summary>
                [XmlEnum(Name = "NONRECTANGULAR")]
                Nonrectangular
            }

            /// <summary>
            /// The package size.
            /// </summary>
            public enum PackageSize
            {
                /// <summary>
                /// The regular.
                /// </summary>
                [XmlEnum(Name = "REGULAR")]
                Regular,

                /// <summary>
                /// The large.
                /// </summary>
                [XmlEnum(Name = "LARGE")]
                Large
            }

            /// <summary>
            /// Gets or sets the ID.
            /// </summary>
            [XmlAttribute(AttributeName = "ID")]
            public string Id { get; set; }

            /// <summary>
            /// Gets or sets the pounds.
            /// </summary>
            [XmlElement]
            public int Pounds { get; set; }

            /// <summary>
            /// Gets or sets the ounces.
            /// </summary>
            [XmlElement]
            public decimal Ounces { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether machinable.
            /// </summary>
            [XmlElement]
            public bool Machinable { get; set; }

            /// <summary>
            /// Gets or sets the value of contents.
            /// </summary>
            [XmlElement]
            public decimal ValueOfContents { get; set; }

            /// <summary>
            /// Gets or sets the country.
            /// </summary>
            [XmlElement]
            public string Country { get; set; }

            /// <summary>
            /// Gets or sets the mail type.
            /// </summary>
            [XmlElement]
            public PackageMailType MailType { get; set; }

            /// <summary>
            /// Gets or sets the container.
            /// </summary>
            [XmlElement]
            public PackageContainer Container { get; set; }

            /// <summary>
            /// Gets or sets the size.
            /// </summary>
            [XmlElement]
            public PackageSize Size { get; set; }

            /// <summary>
            /// Gets or sets the width.
            /// </summary>
            [XmlElement]
            public int Width { get; set; }

            /// <summary>
            /// Gets or sets the length.
            /// </summary>
            [XmlElement]
            public int Length { get; set; }

            /// <summary>
            /// Gets or sets the height.
            /// </summary>
            [XmlElement]
            public int Height { get; set; }

            /// <summary>
            /// Gets or sets the girth.
            /// </summary>
            [XmlElement]
            public int Girth { get; set; }

            /// <summary>
            /// Gets or sets the origin zip.
            /// </summary>
            [XmlElement]
            public string OriginZip { get; set; }

            /// <summary>
            /// Gets or sets the commercial flag.
            /// </summary>
            [XmlElement]
            public string CommercialFlag { get; set; }

            /// <summary>
            /// Gets or sets the extra service.
            /// </summary>
            [XmlArray(ElementName = "ExtraServices")]
            public int ExtraService { get; set; }

            /// <summary>
            /// Gets or sets the global express guaranteed.
            /// </summary>
            [XmlElement(ElementName = "GXG")]
            public PackageGlobalExpressGuaranteed GlobalExpressGuaranteed { get; set; }

            /// <summary>
            /// The global express guaranteed.
            /// </summary>
            public class PackageGlobalExpressGuaranteed
            {
                /// <summary>
                /// Gets or sets the PO box flag.
                /// </summary>
                [XmlElement(ElementName = "POBoxFlag")]
                public string PoBoxFlag { get; set; }

                /// <summary>
                /// Gets or sets the gift flag.
                /// </summary>
                [XmlElement]
                public string GiftFlag { get; set; }
            }
        }
    }
}