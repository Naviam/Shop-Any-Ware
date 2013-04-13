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
    /// This is a class that described additional info for user's delivery address.
    /// </summary>
    public class DeliveryAddress : Address
    {
        /// <summary>
        /// Gets or sets Address Name.
        /// </summary>
        public string AddressName { get; set; }

        /// <summary>
        /// Gets or sets First Name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets Last Name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
            base.Validate();

            if (string.IsNullOrEmpty(this.AddressName))
            {
                this.AddBrokenRule(DeliveryAddressBusinessRules.AddressNameRequired);
            }
            else if (this.AddressName.Length > 40)
            {
                this.AddBrokenRule(DeliveryAddressBusinessRules.AddressNameMaxLength);
            }

            if (string.IsNullOrEmpty(this.FirstName))
            {
                this.AddBrokenRule(DeliveryAddressBusinessRules.FirstNameRequired);
            }
            else if (this.FirstName.Length > 21)
            {
                this.AddBrokenRule(DeliveryAddressBusinessRules.FirstNameMaxLength);
            }

            if (string.IsNullOrEmpty(this.LastName))
            {
                this.AddBrokenRule(DeliveryAddressBusinessRules.LastNameRequired);
            }
            else if (this.LastName.Length > 21)
            {
                this.AddBrokenRule(DeliveryAddressBusinessRules.LastNameMaxLength);
            }
        }
    }
}