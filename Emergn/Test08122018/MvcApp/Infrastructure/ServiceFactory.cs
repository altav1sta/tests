using System;
using Business.Services.Abstract;

namespace MvcApp.Infrastructure
{
    internal sealed class ServiceFactory
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IImageService> _imageService;
        
        public ServiceFactory(Lazy<ICategoryService> categoryService, Lazy<IImageService> imageService)
        {
            _categoryService = categoryService;
            _imageService = imageService;
        }

        public ICategoryService CategoryService => _categoryService.Value;

        public IImageService ImageService => _imageService.Value;
    }
}