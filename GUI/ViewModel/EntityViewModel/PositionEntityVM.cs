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

        public DateTime Startdate
        {
            get
            {
                return tourPosition.Startdate;
            }

            set
            {
                tourPosition.Startdate = value;
            }
        }

        public DateTime Enddate
        {
            get
            {
                return tourPosition.Enddate;
            }

            set
            {
                tourPosition.Enddate = value;
            }
        }

        public string GPSPosition
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

        public string Duration
        {
            get
            {
                return (Enddate - Startdate).ToString();
            }
        }
    }
}
