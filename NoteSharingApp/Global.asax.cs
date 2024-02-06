using NoteSharingApp.Common;
using NoteSharingApp.Initializers;
using System.Web.Mvc;
using System.Web.Routing;

namespace NoteSharingApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            App.Common = new WebCommon();
        }
    }
}
