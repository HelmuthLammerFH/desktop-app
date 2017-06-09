using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class Ressources
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "createdFrom")]
        public string createdFrom { get; set; }
        [DataMember(Name = "picture")]
        public byte[] Picture { get; set; }
        [DataMember(Name = "changedFrom")]
        public string ChangedFrom { get; set; }
        [DataMember(Name = "syncedFrom")]
        public int syncedFrom { get; set; }
        [DataMember(Name = "deleteFlag")]
        public bool DeleteFlag { get; set; }
        [DataMember(Name = "Tour_id")]
        public int Tour_id { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
