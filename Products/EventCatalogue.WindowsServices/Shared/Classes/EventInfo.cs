using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EventCatalogue.Shared.Classes
{
    [DataContract]
    public class EventInfo
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}
