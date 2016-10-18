using System.Web.Mvc;

namespace RequestFlow.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View();
        }

        public ActionResult Authenticate() {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Calc(int val = 0) {
            int result = 100 / val;
            return View("Index");
        }
    }
}
