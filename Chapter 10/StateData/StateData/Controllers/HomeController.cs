using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Mvc;
using StateData.Infrastructure;

namespace StateData.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Counter", AppStateHelper.Get(AppStateKeys.COUNTER, 0));
            IDictionary<AppStateKeys, object> stateData
                = AppStateHelper.GetMultiple(AppStateKeys.LAST_REQUEST_TIME,
                    AppStateKeys.LAST_REQUEST_URL);
            foreach (AppStateKeys key in stateData.Keys) {
                data.Add(Enum.GetName(typeof(AppStateKeys), key), stateData[key]);
            }
            return View(data);
        }

        public ActionResult Increment() {
            int currentValue = (int)AppStateHelper.Get(AppStateKeys.COUNTER, 0);
            AppStateHelper.Set(AppStateKeys.COUNTER, currentValue + 1);
            AppStateHelper.SetMultiple(new Dictionary<AppStateKeys, object> {
                { AppStateKeys.LAST_REQUEST_TIME, HttpContext.Timestamp},
                { AppStateKeys.LAST_REQUEST_URL, Request.RawUrl}
            });
            return RedirectToAction("Index");
        }
    }
}
