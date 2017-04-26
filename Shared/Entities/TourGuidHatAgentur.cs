using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class TourGuidHatAgentur
    {
        [DataMember]
        public Agentur Agentur;

        [DataMember]
        public TourGuide TourGuid;

        [DataMember]
        public DateTime GueltigAb;
    }
}
