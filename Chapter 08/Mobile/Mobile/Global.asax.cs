using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Mobile.Infrastructure;

namespace Mobile {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //HttpCapabilitiesBase.BrowserCapabilitiesProvider = new KindleCapabilities();

            DisplayModeProvider.Instance.Modes.Insert(0,
                new DefaultDisplayMode("Safari") {
                    ContextCondition = (ctx => ctx.Request.Browser.IsBrowser("Safari"))
                });

        }
    }
}
