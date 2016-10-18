using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using StateData.Infrastructure;

namespace StateData.Controllers {
    public class CacheController : Controller {

        public ActionResult Index() {
            SelfExpiringData<long?> seData
                = (SelfExpiringData<long?>)HttpContext.Cache["pageLength"];
            return View(seData == null ? null : seData.Value);
        }

        [HttpPost]
        public async Task<ActionResult> PopulateCache() {

            HttpResponseMessage result
                = await new HttpClient().GetAsync("http://apress.com");
            long? data = result.Content.Headers.ContentLength;

            SelfExpiringData<long?> seData = new SelfExpiringData<long?>(data, 3);
            HttpContext.Cache.Insert("pageLength", seData, seData,
                Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration,
                    HandleNotification);
            return RedirectToAction("Index");
        }

        private void HandleNotification(string key,
            CacheItemUpdateReason reason,
            out object data,
            out CacheDependency dependency,
            out DateTime absoluteExpiry,
            out TimeSpan slidingExpiry) {

            System.Diagnostics.Debug.WriteLine("Item {0} removed. ({1})",
                key, Enum.GetName(typeof(CacheItemUpdateReason), reason));

            data = dependency 
                = new SelfExpiringData<long?>(GetData(false).Result, 3);

            slidingExpiry = Cache.NoSlidingExpiration;
            absoluteExpiry = Cache.NoAbsoluteExpiration;
        }

        private async Task<long?> GetData(bool awaitCon = true) {
            HttpResponseMessage response = await new HttpClient().GetAsync("http://apress.com").ConfigureAwait(awaitCon);
            return response.Content.Headers.ContentLength;
        }

    }
}
