using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Configuration for OWIN use
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

            // Check to migrate database into latest version each time application start
            var initializer = new MigrateDatabaseToLatestVersion<ShopDbContext, Migrations.Configuration>();
            Database.SetInitializer(initializer);
        }
    }
}
