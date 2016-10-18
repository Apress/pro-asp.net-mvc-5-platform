using System.Web.Mvc;
using StateData.Infrastructure;

namespace StateData.Controllers {
    public class RegistrationController : Controller {

        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public ActionResult ProcessFirstForm(string name) {
            SessionStateHelper.Set(SessionStateKeys.NAME, name);
            return View("SecondForm");
        }

        [HttpPost]
        public ActionResult CompleteForm(string country) {
            ViewBag.Name = SessionStateHelper.Get(SessionStateKeys.NAME);
            ViewBag.Country = country;
            return View();
        }
    }
}
