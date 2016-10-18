using System;
using System.Reflection;
using System.Web;

namespace RequestFlow.Infrastructure {
    public class EventListModule : IHttpModule {

        public void Init(HttpApplication app) {

            string[] events = { "BeginRequest", "AuthenticateRequest",
                "PostAuthenticateRequest", "AuthorizeRequest", "ResolveRequestCache",
                "PostResolveRequestCache", "MapRequestHandler", "PostMapRequestHandler",
                "AcquireRequestState", "PostAcquireRequestState", 
                "PreRequestHandlerExecute", "PostRequestHandlerExecute", 
                 "ReleaseRequestState", "PostReleaseRequestState",
                "UpdateRequestCache", "LogRequest", "PostLogRequest",
                "EndRequest", "PreSendRequestHeaders", "PreSendRequestContent"};


            MethodInfo methodInfo = GetType().GetMethod("HandleEvent");
            foreach (string name in events) {
                EventInfo evInfo = app.GetType().GetEvent(name);

                evInfo.AddEventHandler(app, 
                    Delegate.CreateDelegate(evInfo.EventHandlerType,
                        this, methodInfo));
            }

            app.Error += (src, args) => {
                System.Diagnostics.Debug.WriteLine("Event: Error");
            };
        }

        public void HandleEvent(object src, EventArgs args) {
            string name = HttpContext.Current.CurrentNotification.ToString();
            if (HttpContext.Current.IsPostNotification && 
                !HttpContext.Current.Request
                    .CurrentExecutionFilePathExtension.Equals("css")) {
                name = "Post" + name;
            }
            if (name == "BeginRequest") {
                System.Diagnostics.Debug.WriteLine("---------------");
            }
            System.Diagnostics.Debug.WriteLine("Event: {0}", new string[] { name });
        }

        public void Dispose() {
            // do nothing
        }
    }
}