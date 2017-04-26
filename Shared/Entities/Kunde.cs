using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class Kunde
    {
        [DataMember]
        public Guid KundeID { get; set; }

        [DataMember]
        public string Bemerkung { get; set; }

        [DataMember]
        public User User { get; set; }
    }
}
