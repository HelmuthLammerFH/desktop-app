using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class TourGuide
    {
        [DataMember]
        public Guid TourGuideID { get; set; }

        [DataMember]
        public DateTime TourGuideSeitDatum { get; set; }

        [DataMember]
        public User User { get; set; }
    }
}
