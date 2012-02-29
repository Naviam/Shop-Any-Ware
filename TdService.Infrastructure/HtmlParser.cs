// -----------------------------------------------------------------------
// <copyright file="HtmlParser.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using HtmlAgilityPack;
    using ScrapySharp.Extensions;

    /// <summary>
    /// This class is used to parse html pages to get some data from them.
    /// </summary>
    public class HtmlParser
    {
        /// <summary>
        /// Extract retailers from HTML file.
        /// </summary>
        /// <param name="content">
        /// The content.
        /// </param>
        /// <returns>
        /// Collection of the retailers.
        /// </returns>
        public IEnumerable<Retailer> GetOnlineRetailers(StreamReader content)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.Load(content);
            var html = htmlDocument.DocumentNode;

            var retailersHtml = html.CssSelect("#company_listing").CssSelect("div");
            return retailersHtml.Where(retailer => retailer.HasChildNodes)
                .Select(retailerHtml => new Retailer
                {
                    Name = retailerHtml.CssSelect("p[class='company_name'] > a").First().InnerText,
                    Category = retailerHtml.CssSelect("p[class='company_category']").First().InnerText
                });
        }

        /// <summary>
        /// The class contains retailer details.
        /// </summary>
        public class Retailer
        {
            /// <summary>
            /// Gets or sets Name.
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Gets or sets Category.
            /// </summary>
            public string Category { get; set; }
        }
    }
}
