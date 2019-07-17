using EventCatalogue.Application;
using EventCatalogue.Shared.Classes;
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
        public EventCatalogueManager EventCatalogueManager {get; set;}

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            EventCatalogueManager.Start();
        }

        // GET: api/Events
        public IEnumerable<EventInfo> Get()
        {
            return EventCatalogueManager.FindEvents(null, null, false);
        }

        // GET: api/Events/5
        public EventInfo Get(int id)
        {
            return EventCatalogueManager.FindEvents(null, null, false).FirstOrDefault();
        }

        // POST: api/Events
        // add
        public void Post([FromBody]EventInfo value)
        {
            EventCatalogueManager.AddEvent(value);
        }

        // PUT: api/Events/5
        // update
        public void Put(int id, [FromBody]EventInfo value)
        {
        }

        // DELETE: api/Events/5
        public void Delete(int id)
        {
        }
    }
}
