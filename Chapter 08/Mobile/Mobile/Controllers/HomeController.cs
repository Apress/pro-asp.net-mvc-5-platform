using System.Web.Mvc;
using Mobile.Models;

namespace Mobile.Controllers {

    public class HomeController : Controller {

        private Programmer[] progs = { 
            new Programmer("Alice", "Smith", "Lead Developer", "Paris", "France", "C#"),
            new Programmer("Joe", "Dunston", "Developer", "London", "UK", "Java"),
            new Programmer("Peter", "Jones", "Developer", "Chicago", "USA", "C#"),
            new Programmer("Murray", "Woods", "Jnr Developer", "Boston", "USA", "C#")
        };

        public ActionResult Index() {
            HttpContext.Trace.Write("HomeController", "Index Method Started");
            HttpContext.Trace.Write("HomeController",
                string.Format("There are {0} programmers", progs.Length));
            ActionResult result = View(progs);
            HttpContext.Trace.Write("HomeController", "Index Method Completed");
            return result;
        }

        public ActionResult Browser() {
            return View();
        }
    }
}
