using EventCatalogue.Application;
using EventCatalogue.Web.Controllers;
using EventCatelogue.Domain;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;

namespace Web
{
    public class WebApiApplication : HttpApplication
    {
        public void Start()
        {
            Application_Start();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new CustomControllerActivator());
        }

    }
    public class CustomControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return new EventsController(new EventCatalogueManager());
        }
    }
}
