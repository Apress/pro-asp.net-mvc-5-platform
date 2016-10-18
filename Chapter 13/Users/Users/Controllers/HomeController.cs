using System.Web.Mvc;
using System.Collections.Generic;

namespace Users.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            Dictionary<string, object> data
                = new Dictionary<string, object>();
            data.Add("Placeholder", "Placeholder");
            return View(data);
        }
    }
}
