// -----------------------------------------------------------------------
// <copyright file="ValueObjectBase.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The ValueObjectBase class is very similar to the EntityBase
    /// class; expect that an exception will be thrown if it is invalid. The ThrowExceptionIfInvalid will
    /// be called from the subclasses constructor.
    /// </summary>
    public abstract class ValueObjectBase
    {
        /// <summary>
        /// Collection of broken rules.
        /// </summary>
        private readonly List<BusinessRule> brokenRules = new List<BusinessRule>();

        /// <summary>
        /// Exception that is thrown in case of invalid object.
        /// </summary>
        /// <exception cref="ValueObjectIsInvalidException">
        /// ThrowExceptionIfInvalid object.
        /// </exception>
        public void ThrowExceptionIfInvalid()
        {
            this.brokenRules.Clear();
            this.Validate();
            if (this.brokenRules.Any())
            {
                var issues = new StringBuilder();
                foreach (var businessRule in this.brokenRules)
                {
                    issues.AppendLine(businessRule.Rule);
                }

                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        /// <summary>
        /// Method to validate against business rules.
        /// </summary>
        protected abstract void Validate();

        /// <summary>
        /// Add broken rule to collection.
        /// </summary>
        /// <param name="businessRule">
        /// The business rule.
        /// </param>
        protected void AddBrokenRule(BusinessRule businessRule)
        {
            this.brokenRules.Add(businessRule);
        }
    }
}