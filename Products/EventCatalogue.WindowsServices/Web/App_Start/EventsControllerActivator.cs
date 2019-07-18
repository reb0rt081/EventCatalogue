using EventCatalogue.Application;
using EventCatalogue.Web.Controllers;
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
        public EventCatalogueManager CatalogueManager { get;}
        public EventsControllerActivator(EventCatalogueManager eventManager)
        {
            CatalogueManager = eventManager;
        }
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            return new EventsController(CatalogueManager);
        }
    }
}