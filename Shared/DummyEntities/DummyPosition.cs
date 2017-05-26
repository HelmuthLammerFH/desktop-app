using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DummyEntities
{

    public class DummyPosition
    {

        public int PositionID { get; set; }

 
        public string Title { get; set; }

       
        public string Description { get; set; }

      
        public DateTime Startdate { get; set; }

        
        public DateTime Enddate { get; set; }

    
        public string GPSPosition { get; set; }
    
        public decimal Cost { get; set; }
    }
}
