using System.Web.Mvc;

namespace DemoSecuredAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Secured API Demo";

            return View();
        }
    }
}
