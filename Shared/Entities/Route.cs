using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class Route
    {
        [DataMember]
        public Guid RouteID { get; set; }

        [DataMember]
        public string Bezeichnung { get; set; }

        [DataMember]
        public DateTime ErstellDatum { get; set; }

        [DataMember]
        public bool Aktiv { get; set; }

        [DataMember]
        public List<RoutenPosition> RoutenPositionen { get; set; }
    }
}
