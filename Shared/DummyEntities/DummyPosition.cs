using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{
    [DataContract]
    public class DummyPosition
    {
        [DataMember]
        public Guid PositionID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime FromDateTime { get; set; }

        [DataMember]
        public DateTime ToDateTime { get; set; }

        [DataMember]
        public GeoCoordinate GPSPosition { get; set; }

        [DataMember]
        public decimal Cost { get; set; }
    }
}
