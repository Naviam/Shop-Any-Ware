// -----------------------------------------------------------------------
// <copyright file="Criterion.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Querying
{
    /// <summary>
    /// Criterion class.
    /// </summary>
    public class Criterion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Criterion"/> class.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="criteriaOperator">
        /// The criteria operator.
        /// </param>
        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            this.PropertyName = propertyName;
            this.Value = value;
            this.CriteriaOperator = criteriaOperator;
        }

        /// <summary>
        /// Gets PropertyName.
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// Gets Value.
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Gets CriteriaOperator.
        /// </summary>
        public CriteriaOperator CriteriaOperator { get; private set; }
    }
}