using System.Collections.Concurrent;
using System.Web;

namespace SimpleApp.Infrastructure {
    public class CounterHandlerFactory : IHttpHandlerFactory {
        private int counter = 0;
        private int handlerMaxCount = 3;
        private int handlerCount = 0;
        private BlockingCollection<CounterHandler> pool
            = new BlockingCollection<CounterHandler>();

        public IHttpHandler GetHandler(HttpContext context, string verb,
                string url, string path) {

            CounterHandler handler;
            if (!pool.TryTake(out handler)) {
                if (handlerCount < handlerMaxCount) {
                    handlerCount++;
                    handler = new CounterHandler(++counter);
                    pool.Add(handler);
                } else {
                    handler = pool.Take();
                }
            }
            return handler;
        }
        public void ReleaseHandler(IHttpHandler handler) {
            if (handler.IsReusable) {
                pool.Add((CounterHandler)handler);
            } else {
                handlerCount--;
            }
        }
    }
}
