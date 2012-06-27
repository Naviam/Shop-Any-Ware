// -----------------------------------------------------------------------
// <copyright file="Courier.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Shipping
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// Courier service.
    /// </summary>
    public class Courier : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Dispatch Method.
        /// </summary>
        public DispatchMethod DispatchMethod { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                this.AddBrokenRule(CourierBusinessRules.NameRequired);
            }
            else if (this.Name.Length > 64)
            {
                this.AddBrokenRule(CourierBusinessRules.NameMaxLength);
            }
        }
    }
}