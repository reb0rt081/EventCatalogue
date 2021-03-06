﻿using EventCatalogue.Application;
using EventCatalogue.Shared.Classes;
using EventCatelogue.Domain;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace EventCatalogue.Web.Controllers
{
    public class EventsController : ApiController
    {
        [Dependency]
        public IEventManager EventCatalogueManager { get; set; }

        public EventsController(IEventManager eventCatalogueManager)
        {
            EventCatalogueManager = eventCatalogueManager;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
        }

        // GET: api/Events
        public IEnumerable<EventInfo> Get(int maxItems)
        {
            return EventCatalogueManager.FindEvents(null, null, false).Take(maxItems);
        }

        // GET: api/Events/location
        public IEnumerable<EventInfo> Get(string location, int maxItems)
        {
            return EventCatalogueManager.FindEvents(location, null, false).Take(maxItems).ToList();
        }

        // GET: api/Events/date
        public IEnumerable<EventInfo> Get(DateTime date, int maxItems)
        {
            return EventCatalogueManager.FindEvents(null, date, false).Take(maxItems).ToList();
        }

        // GET: api/Events/location&date
        public IEnumerable<EventInfo> Get(string location, DateTime date, bool applyAnd, int maxItems)
        {
            return EventCatalogueManager.FindEvents(location, date, applyAnd).Take(maxItems).ToList();
        }

        // POST: api/Events
        // add
        public void Post([FromBody]EventInfo value)
        {
            EventCatalogueManager.AddEvent(value);
        }

        // PUT: api/Events/5
        // update
        public void Put([FromBody]EventInfo value)
        {
            EventCatalogueManager.UpdateEvent(value);
        }

        // DELETE: api/Events/guid
        public void Delete(Guid id)
        {
            EventCatalogueManager.DeleteEvent(id);
        }
    }
}
