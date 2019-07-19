using EventCatalogue.Application;
using EventCatalogue.Web.Controllers;
using EventCatelogue.Domain;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace EventCatalogue.Web.App_Start
{
    public class EventsControllerActivator : IHttpControllerActivator
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IEventManager CatalogueManager { get; set; }

        
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var eventController = new EventsController(CatalogueManager);
            
            return eventController;
        }
    }
}