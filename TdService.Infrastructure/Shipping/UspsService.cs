// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UspsService.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The usps service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Infrastructure.Shipping
{
    /// <summary>
    /// The USPS service.
    /// </summary>
    public class UspsService : IShippingService
    {
        /// <summary>
        /// The user id.
        /// </summary>
        private readonly string userId;

        /// <summary>
        /// Initializes a new instance of the <see cref="UspsService"/> class.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        public UspsService(string userId)
        {
            this.userId = userId;
        }

        /// <summary>
        /// The track.
        /// </summary>
        /// <param name="trackingNumber">
        /// The tracking number.
        /// </param>
        public void Track(string trackingNumber)
        {
            
        }
    }
}