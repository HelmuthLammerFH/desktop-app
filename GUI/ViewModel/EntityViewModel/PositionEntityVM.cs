using GalaSoft.MvvmLight;
using Shared.DummyEntities;
using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.EntityViewModel
{
    public class PositionEntityVM : ViewModelBase
    {
       private DummyPosition tourPosition;

        public PositionEntityVM(DummyPosition tourPosition)
        {
            this.tourPosition = tourPosition;
        }

       public string Title
        {
            get
            {
                return tourPosition.Title;
            }

            set
            {
                tourPosition.Title = value;
            }
        }

        public string Description
        {
            get
            {
                return tourPosition.Description;
            }

            set
            {
                tourPosition.Description = value;
            }
        }

        public DateTime FromDateTime
        {
            get
            {
                return tourPosition.FromDateTime;
            }

            set
            {
                tourPosition.FromDateTime = value;
            }
        }

        public DateTime ToDateTime
        {
            get
            {
                return tourPosition.ToDateTime;
            }

            set
            {
                tourPosition.ToDateTime = value;
            }
        }

        public GeoCoordinate GPSPosition
        {
            get
            {
                return tourPosition.GPSPosition;
            }

            set
            {
                tourPosition.GPSPosition = value;
            }
        }

        public decimal Cost
        {
            get
            {
                return tourPosition.Cost;
            }

            set
            {
                tourPosition.Cost = value;
            }
        }

        public DummyPosition TourPosition
        {
            get
            {
                return tourPosition;
            }

            set
            {
                tourPosition = value;
            }
        }
    }
}
