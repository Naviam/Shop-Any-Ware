// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShippingHelperTests.cs" company="Naviam">
//   Vitali Hatalski. 2013
// </copyright>
// <summary>
//   Defines the ShippingHelperTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Shipping
{
    using NUnit.Framework;

    using TdService.Infrastructure.Helpers;

    /// <summary>
    /// The shipping helper tests.
    /// </summary>
    [TestFixture]
    public class ShippingHelperTests
    {
        /// <summary>
        /// The should be able to get shipping rates.
        /// </summary>
        [Test]
        public void ShouldBeAbleToGetShippingRates()
        {
            var shipping = new ShippingHelper();
            var total = shipping.GetShippingRate();

            Assert.That(total, Is.Positive);
        }
    }
}
