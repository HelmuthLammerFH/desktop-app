using Newtonsoft.Json;
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
        [JsonProperty( "id")]
        public int ID { get; set; }
        [JsonProperty( "createdFrom")]
        public string createdFrom { get; set; }
        [JsonProperty( "picture")]
        public byte[] Picture { get; set; }
        [JsonProperty( "changedFrom")]
        public string ChangedFrom { get; set; }
        [JsonProperty( "syncedFrom")]
        public int syncedFrom { get; set; }
        [JsonProperty( "deleteFlag")]
        public bool DeleteFlag { get; set; }
        [JsonProperty( "Tour_id")]
        public int Tour_id { get; set; }
        [JsonProperty( "created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty( "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty( "url")]
        public string Url { get; set; }
    }
}
