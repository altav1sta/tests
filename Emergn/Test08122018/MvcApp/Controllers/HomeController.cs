using System.Threading.Tasks;
using System.Web.Mvc;
using MvcApp.Infrastructure;

namespace MvcApp.Controllers
{
    internal class HomeController : Controller
    {
        private readonly ServiceFactory _serviceFactory;
        
        public HomeController(ServiceFactory serviceFactory)
        {
            _serviceFactory = serviceFactory;
        }

        public async Task<ActionResult> Index()
        {
            var categories = await _serviceFactory.CategoryService.GetListAsync();

            return View(categories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}