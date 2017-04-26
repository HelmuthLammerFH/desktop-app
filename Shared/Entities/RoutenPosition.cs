using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class RoutenPosition
    {
        [DataMember]
        public Guid RoutenPositionID {get; set;}

        [DataMember]
        public Guid RouteID { get; set; }

        [DataMember]
        public GeoCoordinate GPSPosition { get; set; }

        [DataMember]
        public string BezeichnungPosition { get; set; }
    }
}
