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
        /// Validate business rules.
        /// </summary>
        protected override void Validate()
        {
        }
    }
}