using System.Collections.Generic;
namespace TdService.Services.Messaging.Item.Base
{
    public class ItemResponse:ResponseBase
    {
        public class ItemImageModel
        {
            public string Url { get; set; }
            public string FileName { get; set; }
        }


        /// <summary>
        /// Gets or sets images
        /// </summary>
        public List<ItemImageModel> Images { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets Weight Pounds.
        /// </summary>
        public int WeightPounds { get; set; }

        /// <summary>
        /// Gets or sets the weight ounces.
        /// </summary>
        public decimal WeightOunces { get; set; }

        /// <summary>
        /// Gets or sets the dimensions length.
        /// </summary>
        public decimal DimensionsLength { get; set; }

        /// <summary>
        /// Gets or sets the dimensions height.
        /// </summary>
        public decimal DimensionsHeight { get; set; }

        /// <summary>
        /// Gets or sets the dimensions width.
        /// </summary>
        public decimal DimensionsWidth { get; set; }

        /// <summary>
        /// Gets or sets the dimensions girth.
        /// </summary>
        public decimal DimensionsGirth { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public decimal Price { get; set; }
    }
}
