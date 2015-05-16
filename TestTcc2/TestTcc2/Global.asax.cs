using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using TestTcc2.Models;
using PayPal;

namespace TestTcc2
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            //System.Data.Entity.Database.SetInitializer(new TestTcc2.Models.DataBasica());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            BundleTable.EnableOptimizations = true;
            PayPal.Profile.Initialize("pedrro2-facilitator_api1.hotmail.com", "1406062798", "A08segknvkFu-7PRGzv4MFShaVgrA5sYXKpdgU9yEhORUI7.m0i.gA4u", "sandbox");

        }
    }
}