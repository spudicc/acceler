using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Acceler.DAL;
using System.Data.Entity.Infrastructure.Interception;
using Acceler.Controllers;

namespace Acceler
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DbInterception.Add(new AccelerInterceptorTransientErrors());
            DbInterception.Add(new AccelerInterceptorLogging());

            GlobalFilters.Filters.Add(new AuthorizeAttribute());
        }

        //protected void Application_EndRequest()
        //{
        //    if (Response.StatusCode == 401)
        //    {
        //        new ErrorController().Unauthorized();
        //        Response.Clear();
        //        Response.Redirect("~/Error/Unauthorized"); // Customize the URL as per your application's structure
        //    }
        //}
    }
}
