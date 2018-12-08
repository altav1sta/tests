namespace Business.Models
{
    /// <summary>
    /// Model for category object
    /// </summary>
    public sealed class Category
    {
        /// <summary>
        /// Unique identifier of category
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of category
        /// </summary>
        public string Name { get; set; }
    }
}
