using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace SimpleApp.Infrastructure {

    public class SiteLengthHandler : HttpTaskAsyncHandler {

        public override async Task ProcessRequestAsync(HttpContext context) {
            string data = await new HttpClient().GetStringAsync("http://www.apress.com");
            context.Response.ContentType = "text/html";
            context.Response.Write(string.Format("<span>Length: {0}</span>",
                data.Length));
        }
    }
}
