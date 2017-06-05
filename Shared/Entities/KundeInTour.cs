using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [DataContract]
    public class KundeInTour
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }
        [DataMember(Name = "bookedDate")]
        public DateTime BookedDate { get; set; }
        [DataMember(Name = "participated")]
        public int Participated { get; set; }
        [DataMember(Name = "starRating")]
        public int StarRating { get; set; }
        [DataMember(Name = "feedbackTourGuid")]
        public string FeedbackTourGuid { get; set; }
        [DataMember(Name = "createdFrom")]
        public string CreatedFrom { get; set; }
        [DataMember(Name = "changedFrom")]
        public string ChangedFrom { get; set; }
        [DataMember(Name = "syncedFrom")]
        public int SyncedFrom { get; set; }
        [DataMember(Name = "deleteFlag")]
        public int DeleteFlag { get; set; }
        [DataMember(Name = "customer_id")]
        public int CustomerID { get; set; }
        [DataMember(Name = "tour_id")]
        public int TourID { get; set; }
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt { get; set; }
        [DataMember(Name = "updated_at")]
        public DateTime UpdatedAt { get; set; }
        [DataMember(Name = "url")]
        public string URL { get; set; }
    }
}
