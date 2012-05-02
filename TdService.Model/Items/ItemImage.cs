// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemImage.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the ItemImage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Items
{
    /// <summary>
    /// Item image.
    /// </summary>
    public class ItemImage
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Gets or sets Path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets PictureType.
        /// </summary>
        public ImageType PictureType { get; set; }
    }
}