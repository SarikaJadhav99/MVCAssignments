using System.Web.Mvc;

namespace NetBankingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();
    }
}