// -----------------------------------------------------------------------
// <copyright file="BusinessRule.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    /// <summary>
    /// This class is used to check the validity of a domain entity prior to persistence.
    /// </summary>
    public class BusinessRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessRule"/> class.
        /// </summary>
        /// <param name="property">
        /// The property.
        /// </param>
        /// <param name="rule">
        /// The rule.
        /// </param>
        public BusinessRule(string property, string rule)
        {
            this.Property = property;
            this.Rule = rule;
        }

        /// <summary>
        /// Gets or sets Property.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Gets or sets Rule.
        /// </summary>
        public string Rule { get; set; }
    }
}