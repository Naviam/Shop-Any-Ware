// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailExistsValidator.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The email exists validator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Account
{
    using System;
    using System.Linq.Expressions;

    using FluentValidation.Validators;

    /// <summary>
    /// The email exists validator.
    /// </summary>
    /// <typeparam name="T">
    /// the type to validate.
    /// </typeparam>
    public class EmailExistsValidator<T> : PropertyValidator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailExistsValidator{T}"/> class.
        /// </summary>
        /// <param name="errorMessageResourceName">
        /// The error message resource name.
        /// </param>
        /// <param name="errorMessageResourceType">
        /// The error message resource type.
        /// </param>
        public EmailExistsValidator(string errorMessageResourceName, Type errorMessageResourceType)
            : base(errorMessageResourceName, errorMessageResourceType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailExistsValidator{T}"/> class.
        /// </summary>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        public EmailExistsValidator(string errorMessage)
            : base(errorMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailExistsValidator{T}"/> class.
        /// </summary>
        /// <param name="errorMessageResourceSelector">
        /// The error message resource selector.
        /// </param>
        public EmailExistsValidator(Expression<Func<string>> errorMessageResourceSelector)
            : base(errorMessageResourceSelector)
        {
        }

        /// <summary>
        /// The is valid.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var email = context.PropertyValue as string;

            return true;
        }
    }
}
