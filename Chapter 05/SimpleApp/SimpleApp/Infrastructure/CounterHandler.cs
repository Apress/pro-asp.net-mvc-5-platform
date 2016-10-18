using System.Web;

namespace SimpleApp.Infrastructure {
    public class CounterHandler : IHttpHandler {
        private int handlerCounter;
        private int requestCounter = 0;

        public CounterHandler(int counter) {
            handlerCounter = counter;
        }

        public void ProcessRequest(HttpContext context) {
            requestCounter++;
            context.Response.ContentType = "text/plain";
            context.Response.Write(
                string.Format("The counter value is {0} (Request {1} of 3)",
                    handlerCounter, requestCounter));
        }

        public bool IsReusable {
            get { return requestCounter < 2; }
        }
    }
}
