// -----------------------------------------------------------------------
// <copyright file="PropertyNameHelper.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Querying
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Property name helper.
    /// </summary>
    public class PropertyNameHelper
    {
        /// <summary>
        /// Resolve property name.
        /// </summary>
        /// <param name="expression">
        /// The expression.
        /// </param>
        /// <typeparam name="T">
        /// Any type of object.
        /// </typeparam>
        /// <returns>
        /// Property name.
        /// </returns>
        public static string ResolvePropertyName<T>(Expression<Func<T, object>> expression)
        {
            var expr = expression.Body as MemberExpression;
            if (expr == null)
            {
                var u = expression.Body as UnaryExpression;
                if (u != null)
                {
                    expr = u.Operand as MemberExpression;
                }
            }

            return expr != null ? expr.ToString().Substring(expr.ToString().IndexOf(".", StringComparison.Ordinal) + 1) : null;
        }
    }
}