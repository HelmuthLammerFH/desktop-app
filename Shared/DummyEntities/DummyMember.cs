using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{
    public class DummyMember
    {
        public int MemberID { get; set; }

        public bool AttendTour { get; set; }

        public DummyUser User { get; set; }
    }
}
