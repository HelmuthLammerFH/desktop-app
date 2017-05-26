using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{

    public class DummyTourGuide
    {
       
        public int ID { get; set; }

        public DateTime TourGuideSince { get; set; }

        public DummyUser User { get; set; }
    }
}
