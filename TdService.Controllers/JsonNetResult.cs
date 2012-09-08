// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonNetResult.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The json net result.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web
{
    using System;
    using System.Text;
    using System.Web.Mvc;

    using Newtonsoft.Json;

    using Formatting = System.Xml.Formatting;

    /// <summary>
    /// The json net result.
    /// </summary>
    public class JsonNetResult : ActionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JsonNetResult"/> class.
        /// </summary>
        public JsonNetResult()
        {
            this.SerializerSettings = new JsonSerializerSettings();
        }

        /// <summary>
        /// Gets or sets the content encoding.
        /// </summary>
        public Encoding ContentEncoding { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the serializer settings.
        /// </summary>
        public JsonSerializerSettings SerializerSettings { get; set; }

        /// <summary>
        /// Gets or sets the formatting.
        /// </summary>
        public Formatting Formatting { get; set; }

        /// <summary>
        /// Execute result.
        /// </summary>
        /// <param name="context">
        /// The controller context.
        /// </param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(this.ContentType)
              ? this.ContentType
              : "application/json";

            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }

            if (this.Data != null)
            {
                var writer = new JsonTextWriter(response.Output) { Formatting = (Newtonsoft.Json.Formatting)this.Formatting };

                var serializer = JsonSerializer.Create(this.SerializerSettings);
                serializer.Serialize(writer, this.Data);

                writer.Flush();
            }
        }
    }
}