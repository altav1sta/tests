using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Services.Abstract
{
    /// <summary>
    /// Service for work with image objects
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Get the list of images for the specific category asynchronously
        /// </summary>
        /// <param name="count">Max count of entries in response</param>
        /// <param name="category">Name of category that images relates to</param>
        /// <returns>Collection of image objects</returns>
        Task<IEnumerable<Image>> GetListAsync(int count, string category);
    }
}
