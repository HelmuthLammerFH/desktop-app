using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{
    [DataContract]
    public class DummyUser
    {
        [DataMember]
        public Guid UserID { get; set; }

        [DataMember]
        public string SureName { get; set; }

        [DataMember]
        public string PreName { get; set; }

        [DataMember]
        public DateTime Birthdate { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
