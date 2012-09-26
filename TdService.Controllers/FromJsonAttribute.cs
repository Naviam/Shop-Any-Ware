// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FromJsonAttribute.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The from JSON attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web
{
    using System.Web.Mvc;
    using System.Web.Script.Serialization;

    /// <summary>
    /// The from JSON attribute.
    /// </summary>
    public class FromJsonAttribute : CustomModelBinderAttribute
    {
        /// <summary>
        /// The serializer.
        /// </summary>
        private readonly static JavaScriptSerializer Serializer = new JavaScriptSerializer();

        /// <summary>
        /// The get binder.
        /// </summary>
        /// <returns>
        /// The <see cref="IModelBinder"/>.
        /// </returns>
        public override IModelBinder GetBinder()
        {
            return new JsonModelBinder();
        }

        /// <summary>
        /// The JSON model binder.
        /// </summary>
        private class JsonModelBinder : IModelBinder
        {
            /// <summary>
            /// The bind model.
            /// </summary>
            /// <param name="controllerContext">
            /// The controller context.
            /// </param>
            /// <param name="bindingContext">
            /// The binding context.
            /// </param>
            /// <returns>
            /// The <see cref="object"/>.
            /// </returns>
            public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                var stringified = controllerContext.HttpContext.Request[bindingContext.ModelName];
                return string.IsNullOrEmpty(stringified) ? null : Serializer.Deserialize(stringified, bindingContext.ModelType);
            }
        }
    }
}