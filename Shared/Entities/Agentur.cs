using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class Agentur
    {
        [DataMember]
        public Guid AgenturID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime DatumEinstieg { get; set; }

        [DataMember]
        public List<TourGuide> TourGuides { get; set; }
    }
}
