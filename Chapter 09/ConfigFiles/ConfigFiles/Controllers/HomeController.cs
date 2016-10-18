using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ConfigFiles.Controllers {

    public class HomeController : Controller {

        public ActionResult Index() {
            Dictionary<string, string> configData = new Dictionary<string, string>();
            SystemWebSectionGroup sysWeb =
                (SystemWebSectionGroup)WebConfigurationManager.OpenWebConfiguration("/")
                    .GetSectionGroup("system.web");
            configData.Add("debug", sysWeb.Compilation.Debug.ToString());
            configData.Add("targetFramework", sysWeb.Compilation.TargetFramework);
            return View(configData);
        }
    }
}
