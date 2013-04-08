namespace TdService.Services.Messaging.Package
{
    public class UpdatePackageTotalSizeRequest:RequestBase
    {
        /// <summary>
        /// Gets or sets Weight Pounds.
        /// </summary>
        public int WeightPounds { get; set; }

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

        public int PackageId { get; set; }
    }
}
