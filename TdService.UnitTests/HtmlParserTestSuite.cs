// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtmlParserTestSuite.cs" company="TdService">
//   Vitali Hatalski. 2012
// </copyright>
// <summary>
//   Defines the HtmlParserTestSuite type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UnitTests
{
    using System.IO;
    using Infrastructure;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    /// <summary>
    /// Test suite for htmlparser class.
    /// </summary>
    [TestClass]
    public class HtmlParserTestSuite
    {
        /// <summary>
        /// Get retailers test.
        /// </summary>
        [TestMethod]
        public void GetRetailersTest()
        {
            // arrange
            var stream = File.OpenRead("RawHtml/top100.htm");
            var parser = new HtmlParser();
            const int ExpectedCount = 100;

            // act
            var retailers = parser.GetOnlineRetailers(new StreamReader(stream)).ToList();

            // assert
            Assert.AreEqual(ExpectedCount, retailers.Count);
        }
    }
}
