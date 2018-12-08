namespace Business.Services.Abstract
{
    /// <summary>
    /// Class that contains all required data for business layer configuration
    /// </summary>
    public interface IBusinessConfiguration
    {
        /// <summary>
        /// Base url of external resource that provides required data
        /// </summary>
        string BaseUrl { get; }
    }
}
