using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class TourPosition
    {
        [DataMember]
        public Guid TourPositionID { get; set; }

        [DataMember]
        public string Bezeichnung { get; set; }

        [DataMember]
        public DateTime VonDatum { get; set; }

        [DataMember]
        public DateTime BisDatum { get; set; }

        [DataMember]
        public Sehenswuerdigkeit Sehenswuerdigkeit { get; set; }
    }
}
