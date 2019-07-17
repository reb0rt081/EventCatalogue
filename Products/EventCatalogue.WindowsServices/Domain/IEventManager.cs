using EventCatalogue.Shared.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventCatelogue.Domain
{
    public interface IEventManager
    {
        /// <summary>
        /// Starts the manager
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the manager
        /// </summary>
        void Stop();

        /// <summary>
        /// Finds events based on search criteria
        /// </summary>
        /// <param name="location"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<EventInfo> FindEvents(string location, DateTime? date, bool combineFilters);

        /// <summary>
        /// Adds a new event into the manager
        /// </summary>
        /// <param name="eventInfo"></param>
        void AddEvent(EventInfo eventInfo);

        /// <summary>
        /// Adds a new event into the manager with a given date
        /// </summary>
        /// <param name="eventInfo"></param>
        void AddEvent(EventInfo eventInfo, DateTime date);

        /// <summary>
        /// Updates an event
        /// </summary>
        /// <param name="eventInfo"></param>
        void UpdateEvent(EventInfo eventInfo);

        /// <summary>
        /// Deletes certain event given its ID
        /// </summary>
        /// <param name="eventId"></param>
        void DeleteEvent(Guid eventId);

    }
}
