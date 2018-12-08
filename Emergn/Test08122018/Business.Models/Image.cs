namespace Business.Models
{
    /// <summary>
    /// Model for the image object
    /// </summary>
    public sealed class Image
    {
        /// <summary>
        /// Unique identifier of the image
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Url for displaying the image
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Source url of the image
        /// </summary>
        public string SourceUrl { get; set; }
    }
}
