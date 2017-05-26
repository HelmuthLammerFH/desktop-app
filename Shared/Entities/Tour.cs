using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class Tour
    {
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxAttendees { get; set; }
        public float Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CreatedFrom { get; set; }
        public string ChangedFrom { get; set; }
        public int SyncedFrom { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int TourGuideID { get; set; }
        public int StatusID { get; set; }


    }
}
