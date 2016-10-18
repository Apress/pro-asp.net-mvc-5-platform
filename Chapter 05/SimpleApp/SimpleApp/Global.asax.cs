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
            BeginRequest += (src, args) => {
                if (Request.RawUrl == "/Day") {
                    Response.Write(System.DateTime.Now.DayOfWeek.ToString());
                    CompleteRequest();
                }
            };
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
