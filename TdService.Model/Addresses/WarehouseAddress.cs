// -----------------------------------------------------------------------
// <copyright file="WarehouseAddress.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Addresses
{
    /// <summary>
    /// This class describes the warehouse address of TD Service for the user.
    /// </summary>
    public class WarehouseAddress : DeliveryAddress
    {
        /// <summary>
        /// Gets or sets Room Number.
        /// </summary>
        public string RoomNumber { get; set; }
    }
}