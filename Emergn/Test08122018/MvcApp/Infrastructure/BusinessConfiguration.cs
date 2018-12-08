using Business.Services.Abstract;

namespace MvcApp.Infrastructure
{
    internal class BusinessConfiguration : IBusinessConfiguration
    {
        public BusinessConfiguration()
        {
            BaseUrl = System.Configuration.ConfigurationManager.AppSettings["ServiceBaseUrl"];
        }

        public string BaseUrl { get; }
    }
}