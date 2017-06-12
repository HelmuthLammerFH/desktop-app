using GalaSoft.MvvmLight;
using Shared.DummyEntities;
using Shared.Entities;
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

        public float Cost
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

        public DateTime StartDate
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

        public DateTime EndDate
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
                return (EndDate - StartDate).ToString();
            }
        }

        public string CreatedFrom
        {
            get { return tourPosition.CreatedFrom; }
            set { tourPosition.CreatedFrom = value; }
        }

        public string ChangedFrom
        {
            get { return tourPosition.ChangedFrom; }
            set { tourPosition.ChangedFrom = value; }
        }

    }
}
