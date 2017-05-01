using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{
    [DataContract]
    public class DummyTourGuide
    {
        [DataMember]
        public Guid TourGuideID { get; set; }

        [DataMember]
        public DummyUser User { get; set; }
    }
}
