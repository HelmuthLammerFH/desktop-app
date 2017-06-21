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
        if(value is string && !String.IsNullOrEmpty((string)value))
            {
                var valueArray = value.ToString().Split(';');
                // needed for map
                GeoCoordinate gc = new GeoCoordinate(double.Parse(valueArray[0]), double.Parse(valueArray[1]));
                return new Location(gc.Latitude,gc.Longitude);
            }
            return new Location(48.23965, 16.37779);


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
