using System.Web;
using System.Web.Mvc;
using StateData.Infrastructure;

namespace StateData.Controllers {
    public class LifecycleController : Controller {

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult Index(bool store = false, bool abandon = false) {
            if (store) {
                SessionStateHelper.Set(SessionStateKeys.NAME, "Adam");
            }
            if (abandon) {
                Session.Abandon();
            }
            return RedirectToAction("Index");
        }
    }
}
