using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{
    [DataContract]
    public class DummyMember
    {
        [DataMember]
        public Guid MemberID { get; set; }

        [DataMember]
        public bool AttendTour { get; set; }

        [DataMember]
        public DummyUser User { get; set; }
    }
}
