using MagniUniversity.Service.Interface;
using System.Web.Mvc;

namespace MagniUniversity.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseService _service;

        public HomeController(ICourseService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var courses = _service.List();
            return View();
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