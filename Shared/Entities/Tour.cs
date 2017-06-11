using Newtonsoft.Json;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class Tour
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("maxAttendees")]
        public int MaxAttendees { get; set; }
        [JsonProperty("price")]
        public float Price { get; set; }
        [JsonProperty("startDate")]
        public DateTime StartDate { get; set; }
        [JsonProperty("endDate")]
        public DateTime EndDate { get; set; }
        [JsonProperty("createdFrom")]
        public string CreatedFrom { get; set; }
        [JsonProperty("changedFrom")]
        public string ChangedFrom { get; set; }
        [JsonProperty("syncedFrom")]
        public int SyncedFrom { get; set; }
        [JsonProperty("deleteFlag")]
        public bool DeleteFlag { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("Tourguide_id")]
        public int TourGuideID { get; set; }
        [JsonProperty("status_id")]
        public int StatusID { get; set; }
        [JsonProperty("url ")]
        public string Url { get; set; }

    }
}
