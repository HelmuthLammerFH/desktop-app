using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Shared.Entities
{

    public class TourGuide
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("tourGuideSince")]
        public DateTime TourGuideSince { get; set; }
        [JsonProperty("position")]
        public string Position { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public float Price { get; set; }
        [JsonProperty("createdFrom")]
        public string CreatedFrom { get; set; }
        [JsonProperty("changedFrom")]
        public string ChangedFrom { get; set; }
        [JsonProperty("syncedFrom")]
        public int SyncedFrom { get; set; }
        [JsonProperty("deleteFlag")]
        public bool DeleteFlag { get; set; }
        [JsonProperty("user_id")]
        public int UserID { get; set; }
        [JsonProperty("agency_id")]
        public object AgencyID { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
