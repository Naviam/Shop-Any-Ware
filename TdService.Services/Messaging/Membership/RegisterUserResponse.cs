// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterUserResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the RegisterUserResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// Register user response for service.
    /// </summary>
    public class RegisterUserResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notify on order status changed.
        /// </summary>
        public bool NotifyOnOrderStatusChanged { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether notify on package status changed.
        /// </summary>
        public bool NotifyOnPackageStatusChanged { get; set; }

        /// <summary>
        /// Gets or sets the activation code.
        /// </summary>
        public string ActivationCode { get; set; }
    }
}