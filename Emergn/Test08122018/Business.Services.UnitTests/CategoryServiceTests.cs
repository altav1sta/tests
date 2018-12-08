using System.Threading.Tasks;
using Business.Services.Abstract;
using Business.Services.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Business.Services.UnitTests
{
    [TestClass]
    public class CategoryServiceTests
    {
        private ICategoryService _categoryService;

        [TestInitialize]
        public void Initialize()
        {
            var configuration = new Mock<IBusinessConfiguration>();
            configuration.Setup(x => x.BaseUrl).Returns("http://thecatapi.com/api/");
            _categoryService = new CategoryService(configuration.Object);
        }

        [TestMethod]
        public async Task GetList_Success()
        {
            // Arrange 

            // Act
            var categories =  await _categoryService.GetListAsync();
            
            // Assert
            Assert.IsNotNull(categories);
        }
    }
}
