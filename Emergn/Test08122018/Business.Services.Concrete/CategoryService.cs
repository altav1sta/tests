using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Business.Models;
using Business.Services.Abstract;
using Business.Services.Concrete.DTO;

namespace Business.Services.Concrete
{
    /// <inheritdoc cref="ICategoryService"/>
    public sealed class CategoryService : ICategoryService
    {
        private const string GetListUrlSuffix = @"categories/list";

        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Create an instance of <see cref="CategoryService"/> class
        /// </summary>
        /// <param name="config">Configuration parameters</param>
        public CategoryService(IBusinessConfiguration config)
        {
            Client.BaseAddress = new Uri(config.BaseUrl);
        }

        /// <inheritdoc cref="ICategoryService.GetListAsync"/>
        public async Task<IEnumerable<Category>> GetListAsync()
        {
            using (var response = await Client.GetAsync(GetListUrlSuffix))
            {
                if (response.IsSuccessStatusCode)
                {
                    var categories = await response.Content.ReadAsAsync<IEnumerable<Category>>();
                    return categories;
                }
            }

            return null;
        }
    }
}
