using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleApp {
    public class MvcApplication : System.Web.HttpApplication {

        public MvcApplication() {
            PostAcquireRequestState += (src, args) => CreateTimeStamp();
        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CreateTimeStamp();
        }

        private void CreateTimeStamp() {
            string stamp = Context.Timestamp.ToLongTimeString();
            if (Context.Session != null) {
                Session["request_timestamp"] = stamp;
            } else {
                Application["app_timestamp"] = stamp;
            }
        }
    }
}
