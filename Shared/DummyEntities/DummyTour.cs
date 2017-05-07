using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{
    [DataContract]
    public class DummyTour
    {
        [DataMember]
        public Guid TourID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public List<DummyPosition> Positions { get; set; }

        [DataMember]
        public List<DummyMember> Members { get; set; }

        [DataMember]
        public DummyTourGuide TourGuide { get; set; }
    }
}
