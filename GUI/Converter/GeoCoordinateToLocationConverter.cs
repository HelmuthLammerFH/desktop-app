using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GUI.Converter
{
   public class GeoCoordinateToLocationConverter : IValueConverter    
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
        if(value is GeoCoordinate)
            {
                // needed for map
                GeoCoordinate gc = (GeoCoordinate)value;
                return new Location(gc.Latitude,gc.Longitude);
            }
            return null;
         
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
