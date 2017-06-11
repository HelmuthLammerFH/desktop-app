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
    public class TourToPositions
    {
        [JsonProperty("id")]
        public int ID { get; set; }
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
        [JsonProperty("Tourposition_id")]
        public int TourpositionID { get; set; }
        [JsonProperty("tour_id")]
        public int TourID { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
