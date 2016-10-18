using System;
using System.Web.Caching;

namespace StateData.Infrastructure {
    public class SelfExpiringData<T> : CacheDependency {
        private T dataValue;
        private int requestCount = 0;
        private int requestLimit;

        public T Value {
            get {
                if (requestCount++ >= requestLimit) {
                    NotifyDependencyChanged(this, EventArgs.Empty);
                }
                return dataValue;
            }
        }

        public SelfExpiringData(T data, int limit) {
            dataValue = data;
            requestLimit = limit;
        }
    }
}
