using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class KundeInTour
    {
        [DataMember]
        public Tour Tour { get; set; }

        [DataMember]
        public Kunde Kunde { get; set; }

        [DataMember]
        public DateTime Datum { get; set; }

        [DataMember]
        public bool Teilgenommen { get; set; }

        [DataMember]
        public int SterneBewertung { get; set; }

        [DataMember]
        public string Feedback { get; set; }
    }
}
