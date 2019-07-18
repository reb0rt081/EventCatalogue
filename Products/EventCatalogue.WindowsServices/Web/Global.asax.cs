using EventCatalogue.Application;
using EventCatalogue.Web.App_Start;
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
        private IUnityContainer container;
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

            WebLoader();
        }

        protected void WebLoader()
        {
            #region Create container and register services

            container = new UnityContainer();
            container.RegisterInstance(container);

            EventCatalogueManager eventManager = new EventCatalogueManager();
            container.RegisterInstance<IEventManager>(eventManager);
            
            EventsControllerActivator eventsControllerActivator = new EventsControllerActivator();
            container.RegisterInstance<IHttpControllerActivator>(eventsControllerActivator);

            #endregion

            #region Build up services

            container.BuildUp(eventManager);
            container.BuildUp(eventsControllerActivator);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), eventsControllerActivator);

            #endregion

            #region Start services

            eventManager.Start();

            #endregion
        }

    }    
}
