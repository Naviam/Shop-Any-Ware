// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShippingService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The ShippingService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Shipping
{
    /// <summary>
    /// The ShippingService interface.
    /// </summary>
    public interface IShippingService
    {
        /// <summary>
        /// The track.
        /// </summary>
        /// <param name="trackingNumber">
        /// The tracking number.
        /// </param>
        void Track(string trackingNumber);
    }
}
