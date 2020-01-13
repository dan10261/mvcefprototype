using mvcEFprototype.Filters;
using mvcEFprototype.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace mvcEFprototype
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            //Enable code First approach
            //Database.SetInitializer<DBConfigurationContext>(new DropCreateDatabaseIfModelChanges<DBConfigurationContext>());
            Database.SetInitializer<DBConfigurationContext>(new DropCreateDatabaseAlways<DBConfigurationContext>());

            //Register global action filter
            GlobalFilters.Filters.Add(new CustomExceptionHandler());
            
        }
    }
}
