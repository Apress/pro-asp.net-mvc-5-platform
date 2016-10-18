using System.Web;

namespace Mobile.Infrastructure {
    public class LogModule : IHttpModule {
        private const string traceCategory = "LogModule";

        public void Init(HttpApplication app) {
            app.BeginRequest += (src, args) => {
                HttpContext.Current.Trace.Write(traceCategory, "BeginRequest");
            };

            app.EndRequest += (src, args) => {
                HttpContext.Current.Trace.Write(traceCategory, "EndRequest");
            };

            app.PostMapRequestHandler += (src, args) => {
                HttpContext.Current.Trace.Write(traceCategory,
                    string.Format("Handler: {0}",
                        HttpContext.Current.Handler));
            };

            app.Error += (src, args) => {
                HttpContext.Current.Trace.Warn(traceCategory, string.Format("Error: {0}",
                    HttpContext.Current.Error.GetType().Name));
            };
        }

        public void Dispose() {
            // do nothing
        }
    }
}
