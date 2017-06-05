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
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "maxAttendees")]
        public int MaxAttendees { get; set; }
        [DataMember(Name = "price")]
        public float Price { get; set; }
        [DataMember(Name = "startDate")]
        public DateTime StartDate { get; set; }
        [DataMember(Name = "endDate")]
        public DateTime EndDate { get; set; }
        [DataMember(Name = "createdFrom")]
        public string CreatedFrom { get; set; }
        [DataMember(Name = "changedFrom")]
        public string ChangedFrom { get; set; }
        [DataMember(Name = "syncedFrom")]
        public int SyncedFrom { get; set; }
        [DataMember(Name = "deleteFlag")]
        public int DeleteFlag { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [DataMember(Name = "Tourguide_id")]
        public int TourGuideID { get; set; }
        [DataMember(Name = "status_id")]
        public int StatusID { get; set; }
        [DataMember(Name = "url ")]
        public string Url { get; set; }

    }
}
