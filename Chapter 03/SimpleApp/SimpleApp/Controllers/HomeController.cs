using System.Collections.Generic;
using System.Web.Mvc;
using SimpleApp.Models;

namespace SimpleApp.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {
            return View(GetTimeStamps());
        }

        [HttpPost]
        public ActionResult Index(Color color) {
            Color? oldColor = Session["color"] as Color?;
            if (oldColor != null) {
                Votes.ChangeVote(color, (Color)oldColor);
            } else {
                Votes.RecordVote(color);
            }
            ViewBag.SelectedColor = Session["color"] = color;
            return View(GetTimeStamps());
        }

        private List<string> GetTimeStamps() {
            return new List<string> {
                string.Format("App timestamp: {0}", 
                    HttpContext.Application["app_timestamp"]),
                string.Format("Request timestamp: {0}", Session["request_timestamp"]),
            };
        }
    }
}
