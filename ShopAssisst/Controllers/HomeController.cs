using System.Web.Mvc;
using ShopAssist2.Common.Persistence;

namespace ShopAssisst2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopAssist2Context _ctx = new ShopAssist2Context();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
    }
}