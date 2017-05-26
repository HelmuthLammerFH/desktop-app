using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{

    public class TourGuide
    {
        public int TourGuideID { get; set; }
        public DateTime TourGuideSeitDatum { get; set; }
        public User User { get; set; }
    }
}
