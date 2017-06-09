using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{

    public class TourGuide
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "tourGuideSince")]
        public DateTime TourGuideSince { get; set; }
        [DataMember(Name = "position")]
        public string Position { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "price")]
        public float Price { get; set; }
        [DataMember(Name = "createdFrom")]
        public string CreatedFrom { get; set; }
        [DataMember(Name = "changedFrom")]
        public string ChangedFrom { get; set; }
        [DataMember(Name = "syncedFrom")]
        public int SyncedFrom { get; set; }
        [DataMember(Name = "deleteFlag")]
        public bool DeleteFlag { get; set; }
        [DataMember(Name = "user_id")]
        public int UserID { get; set; }
        [DataMember(Name = "agency_id")]
        public object AgencyID { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [DataMember(Name = "url")]
        public string URL { get; set; }
    }
}
