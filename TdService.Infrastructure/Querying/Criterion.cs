// -----------------------------------------------------------------------
// <copyright file="Criterion.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Querying
{
    using System;
    using System.Linq.Expressions;

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

        /// <summary>
        /// Create criterion.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="criteriaOperator">
        /// The criteria operator.
        /// </param>
        /// <typeparam name="T">
        /// Any object type.
        /// </typeparam>
        /// <returns>
        /// Criterion object.
        /// </returns>
        public static Criterion Create<T>(Expression<Func<T, object>> expression, object value, CriteriaOperator criteriaOperator)
        {
            var propertyName = PropertyNameHelper.ResolvePropertyName(expression);
            var myCriterion = new Criterion(propertyName, value, criteriaOperator);
            return myCriterion;
        }
    }
}