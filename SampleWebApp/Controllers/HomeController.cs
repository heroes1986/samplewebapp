using System.Web.Mvc;
using SampleWebApp.Services;

namespace SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController()
            :this(new HomeService())
        {
            
        }

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public ActionResult Index()
        {
            var index = _homeService.GetIndexName();
            return View(index);
        }

        public ActionResult About()
        {
            ViewBag.Message = _homeService.GetAboutDescription();

            return View("About");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = _homeService.GetContractMessage();

            return View();
        }
    }
}