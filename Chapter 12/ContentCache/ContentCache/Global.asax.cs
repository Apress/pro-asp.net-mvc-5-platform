using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ContentCache {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public override string GetVaryByCustomString(HttpContext ctx, string custom) {
            if (custom == "mobile") {
                return Request.Browser.IsMobileDevice.ToString();
            } else {
                return base.GetVaryByCustomString(ctx, custom);
            }
        }
    }
}
