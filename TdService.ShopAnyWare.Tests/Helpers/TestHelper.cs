// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestHelper.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The test helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Helpers
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using NUnit.Framework;

    /// <summary>
    /// The test helper.
    /// </summary>
    internal static class TestHelper
    {
        /// <summary>
        /// Assert is authorized helper.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        internal static void AssertIsAuthorized(ICustomAttributeProvider type)
        {
            Assert.IsTrue(type.GetCustomAttributes(false).Any(o => o.GetType() == typeof(AuthorizeAttribute)));
        }

        /// <summary>
        /// Assert is authorized helper.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="action">
        /// The action.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        internal static void AssertIsAuthorized(Type type, string action, params Type[] parameters)
        {
            var methodInfo = type.GetMethod(action, parameters);
            AssertIsAuthorized(methodInfo);
        }
    }
}
