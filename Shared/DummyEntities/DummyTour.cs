using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{
    public class DummyTour
    {

        public int ID { get; set; }

        public string Name { get; set; }
        public int MaxAttendees { get; set; }

        public float Price { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string State { get; set; }

        public List<DummyPosition> Positions { get; set; }

        public List<DummyMember> Members { get; set; }

        public DummyTourGuide TourGuide { get; set; }
    }
}
