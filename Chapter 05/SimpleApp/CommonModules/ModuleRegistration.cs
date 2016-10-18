using System.Web;

//[assembly: PreApplicationStartMethod(typeof(CommonModules.ModuleRegistration),
//    "RegisterModule")]

namespace CommonModules {
    public class ModuleRegistration {

        public static void RegisterModule() {
            HttpApplication.RegisterModule(typeof(CommonModules.InfoModule));
        }
    }
}
