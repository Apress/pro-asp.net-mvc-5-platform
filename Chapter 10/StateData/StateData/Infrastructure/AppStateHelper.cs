using System;
using System.Web;
using System.Collections.Generic;

namespace StateData.Infrastructure {

    public enum AppStateKeys {
        COUNTER,
        LAST_REQUEST_TIME,
        LAST_REQUEST_URL
    };

    public static class AppStateHelper {

        public static object Get(AppStateKeys key, object defaultValue = null) {
            string keyString = Enum.GetName(typeof(AppStateKeys), key);
            if (HttpContext.Current.Application[keyString] == null
                    && defaultValue != null) {
                HttpContext.Current.Application[keyString] = defaultValue;
            }
            return HttpContext.Current.Application[keyString];
        }

        public static object Set(AppStateKeys key, object value) {
            return HttpContext.Current.Application[Enum.GetName(typeof(AppStateKeys),
                key)] = value;
        }

        public static IDictionary<AppStateKeys, object>
            GetMultiple(params AppStateKeys[] keys) {

            Dictionary<AppStateKeys, object> results
                = new Dictionary<AppStateKeys, object>();
            HttpApplicationState appState = HttpContext.Current.Application;
            appState.Lock();
            foreach (AppStateKeys key in keys) {
                string keyString = Enum.GetName(typeof(AppStateKeys), key);
                results.Add(key, appState[keyString]);
            }
            appState.UnLock();
            return results;
        }

        public static void SetMultiple(IDictionary<AppStateKeys, object> data) {
            HttpApplicationState appState = HttpContext.Current.Application;
            appState.Lock();
            foreach (AppStateKeys key in data.Keys) {
                string keyString = Enum.GetName(typeof(AppStateKeys), key);
                appState[keyString] = data[key];
            }
            appState.UnLock();
        }
    }
}
