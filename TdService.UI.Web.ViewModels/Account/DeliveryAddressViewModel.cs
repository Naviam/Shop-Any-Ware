namespace TdService.UI.Web.ViewModels.Account
{
    /// <summary>
    /// The delivery address view model.
    /// </summary>
    public class DeliveryAddressViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets FirstName.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets LastName.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets Zip.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets Region.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets Address Line 1.
        /// </summary>
        public string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets Address Line 2.
        /// </summary>
        public string AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets Address Line 3.
        /// </summary>
        public string AddressLine3 { get; set; }

        /// <summary>
        /// Gets or sets Phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets State.
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets AddressName.
        /// </summary>
        public string AddressName { get; set; }
    }
}