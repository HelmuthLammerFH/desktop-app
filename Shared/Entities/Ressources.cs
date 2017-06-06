using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
   
    public class Ressources
    {
        public int id { get; set; }
        public object createdFrom { get; set; }
        public string picture { get; set; }
        public string changedFrom { get; set; }
        public int syncedFrom { get; set; }
        public object deleteFlag { get; set; }
        public int Tour_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
    }
}
