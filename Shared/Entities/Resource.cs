using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class ResourceFuerTour
    {
        [DataMember]
        public Guid ResourceFuerTourID { get; set; }

        [DataMember]
        public Guid TourID { get; set; }

        [DataMember]
        public ResourceTyp ResourceTyp { get; set; }

        [DataMember]
        public string Resource { get; set; }

        [DataMember]
        public DateTime Datum { get; set; }

        [DataMember]
        public DateTime Uhrzeit { get; set; }
    }
}
