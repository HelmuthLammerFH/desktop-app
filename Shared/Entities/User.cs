using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class User
    {
        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public string Nachname { get; set; }

        [DataMember]
        public string Vorname { get; set; }

        [DataMember]
        public DateTime Geburtsdatum { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Addresse { get; set; }

        [DataMember]
        public string Ort { get; set; }

        [DataMember]
        public string Passwort { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
