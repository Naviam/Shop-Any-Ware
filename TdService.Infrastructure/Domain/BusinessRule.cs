// -----------------------------------------------------------------------
// <copyright file="BusinessRule.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    using System.Resources;

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
        /// <param name="errorCode">
        /// The error code.
        /// </param>
        public BusinessRule(string property, string errorCode)
        {
            this.Property = property;
            this.ErrorCode = errorCode;
        }

        /// <summary>
        /// Gets or sets Property.
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Gets or sets Error Code.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Gets the rule.
        /// </summary>
        public string Rule
        {
            get
            {
                return new ResourceManager(typeof(Resources.ErrorCodeResources)).GetString(this.ErrorCode);
            }
        }
    }
}