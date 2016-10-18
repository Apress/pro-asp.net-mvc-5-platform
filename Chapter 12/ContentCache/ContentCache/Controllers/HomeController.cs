using System.Diagnostics;
using System.Threading;
using System.Web.Mvc;
using System.Web.UI;
using ContentCache.Infrastructure;
using System;
using System.Web;

namespace ContentCache.Controllers {
    public class HomeController : Controller {

        public ActionResult Index() {

            Response.Cache.SetExpires(DateTime.Now.AddSeconds(30));
            Response.Cache.SetCacheability(HttpCacheability.Server);
            Response.Cache.AddValidationCallback(CheckCachedItem, Request.UserAgent);

            Thread.Sleep(1000);
            int counterValue = AppStateHelper.IncrementAndGet(
                AppStateKeys.INDEX_COUNTER);
            Debug.WriteLine(string.Format("INDEX_COUNTER: {0}", counterValue));
            return View(counterValue);
        }

        [ChildActionOnly]
        [OutputCache(Duration = 60)]
        public PartialViewResult GetTime() {
            return PartialView((object)DateTime.Now.ToShortTimeString());
        }

        public void CheckCachedItem(HttpContext ctx, object data,
            ref HttpValidationStatus status) {

            status = data.ToString() == ctx.Request.UserAgent ?
                HttpValidationStatus.Valid : HttpValidationStatus.Invalid;
            Debug.WriteLine("Cache Status: " + status);
        }
    }
}
