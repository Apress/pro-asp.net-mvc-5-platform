using System;
using System.Web;

namespace SimpleApp.Infrastructure {
    public class DayOfWeekHandler : IHttpHandler, IRequiresDate {

        public void ProcessRequest(HttpContext context) {

            if (context.Items.Contains("DayModule_Time")
                    && (context.Items["DayModule_Time"] is DateTime)) {

                string day = ((DateTime)context.Items["DayModule_Time"])
                    .DayOfWeek.ToString();

                if (context.Request.CurrentExecutionFilePathExtension == ".json") {
                    context.Response.ContentType = "application/json";
                    context.Response.Write(string.Format("{{\"day\": \"{0}\"}}", day));
                } else {
                    context.Response.ContentType = "text/html";
                    context.Response.Write(string.Format("<span>It is: {0}</span>",
                        day));
                }

            } else {
                context.Response.ContentType = "text/html";
                context.Response.Write("No Module Data Available");
            }
        }

        public bool IsReusable {
            get { return false; }
        }
    }
}
