using EventCatalogue.Shared.Classes;
using EventCatelogue.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCatalogue.Application
{
    public class EventCatalogueManager : IEventManager
    {
        public bool IsStarted { get; private set; }

        private Dictionary<Guid, EventInfo> eventDictionaty;

        public EventCatalogueManager()
        {
            IsStarted = false;
        }

        public void AddEvent(EventInfo eventInfo)
        {
            AddEvent(eventInfo, DateTime.Today);
        }

        public void AddEvent(EventInfo eventInfo, DateTime date)
        {
            if(IsStarted)
            {
                eventInfo.DateCreated = date;
                eventInfo.Id = Guid.NewGuid();

                eventDictionaty.Add(eventInfo.Id, eventInfo);
            }
        }

        public void DeleteEvent(Guid eventId)
        {
            if(IsStarted && eventDictionaty.ContainsKey(eventId))
            {
                eventDictionaty.Remove(eventId);
            }
        }

        public List<EventInfo> FindEvents(string location, DateTime? date, bool combineFilters)
        {
            if(IsStarted)
            {
                if (string.IsNullOrEmpty(location) && date == null)
                {
                    return eventDictionaty.Values.ToList();
                }

                if (combineFilters)
                {
                    return eventDictionaty.Values.Where(ev => ev.DateCreated == date && ev.Location == location).ToList();
                }
                else
                {
                    return eventDictionaty.Values.Where(ev => ev.DateCreated == date || ev.Location == location).ToList();
                }
            }

            return new List<EventInfo>();            
        }

        public void Start()
        {
            eventDictionaty = new Dictionary<Guid, EventInfo>();
            IsStarted = true;
            //  Recovery of events should happen here
        }

        public void Stop()
        {
            // Saving events should happen here
            IsStarted = false;
        }

        public void UpdateEvent(EventInfo eventInfo)
        {
            if(IsStarted && eventDictionaty.ContainsKey(eventInfo.Id))
            {
                eventDictionaty[eventInfo.Id] = eventInfo;
            }
        }
    }
}
