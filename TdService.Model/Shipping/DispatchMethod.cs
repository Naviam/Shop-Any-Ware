// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DispatchMethod.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Post service and method which will be used to send parcel to the user's delivery address
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Shipping
{
    /// <summary>
    /// Post service and method which will be used to send parcel to the user's delivery address
    /// </summary>
    public enum DispatchMethod
    {
        /// <summary>
        /// Express mail delivery
        /// </summary>
        ExpressMail,

        /// <summary>
        /// Priority mail delivery
        /// </summary>
        PriorityMail
    }
}