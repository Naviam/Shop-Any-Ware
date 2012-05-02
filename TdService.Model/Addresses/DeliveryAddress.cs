// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryAddress.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the DeliveryAddress type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    /// <summary>
    /// This is a class that descibed additional info for user's delivery address.
    /// </summary>
    public class DeliveryAddress : Address
    {
        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        public string LastName { get; set; }
    }
}