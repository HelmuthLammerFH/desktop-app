using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [DataContract]
    public class Tour
    {
        [DataMember]
        public Guid TourID { get; set; }

        [DataMember]
        public string Bezeichnung { get; set; }

        [DataMember]
        public DateTime Datum { get; set; }

        [DataMember]
        public int Teilnehmeranzahl { get; set; }

        [DataMember]
        public Status Status { get; set; }

        [DataMember]
        public DateTime Dauer { get; set; }

        [DataMember]
        public Route Route { get; set; }

        [DataMember]
        public List<ResourceFuerTour> Resourcen { get; set; }

        [DataMember]
        public Agentur Agentur { get; set; }

        [DataMember]
        public List<KundeInTour> Kunden { get; set; }

        [DataMember]
        public List<TourPosition> TourPositionen { get; set; }

        [DataMember]
        public TourGuide TourGuide { get; set; }
    }
}
