using Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    /// <summary>
    /// Service for work with categories
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Get the list of all available categories asynchronously
        /// </summary>
        /// <returns>Collection of available categories</returns>
        Task<IEnumerable<Category>> GetListAsync();
    }
}
