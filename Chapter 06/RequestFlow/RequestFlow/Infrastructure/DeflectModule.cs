using System.Web;

namespace RequestFlow.Infrastructure {
    public class DeflectModule : IHttpModule {

        public void Init(HttpApplication app) {
            app.BeginRequest += (src, args) => {
                if (app.Request.RawUrl.ToLower().StartsWith("/home")) {
                    app.Response.StatusCode = 500;
                    app.CompleteRequest();
                }
            };
        }

        public void Dispose() {
            // do nothing
        }
    }
}
