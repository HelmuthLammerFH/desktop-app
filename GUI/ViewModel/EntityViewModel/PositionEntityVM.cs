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
       private TourPosition tourPosition;
        private TourToPositions tourToPosition;

        public PositionEntityVM(TourPosition tourPosition, TourToPositions tourToPosition = null)
        {
            this.tourPosition = tourPosition;
            this.tourToPosition = tourToPosition;
        }

       public string Title
        {
            get
            {
                return tourPosition.Name;
            }

            set
            {
                tourPosition.Name = value;
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
                return tourPosition.Position;
            }

            set
            {
                tourPosition.Position = value;
            }
        }

        public float Cost
        {
            get
            {
                return tourPosition.Price;
            }

            set
            {
                tourPosition.Price = value;
            }
        }

        public TourPosition TourPosition
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

        public TourToPositions TourToPosition
        {
            get
            {
                return tourToPosition;
            }

            set
            {
                tourToPosition = value;
            }
        }

        public string Duration
        {
            get
            {
                return (TourToPosition.EndDate - TourToPosition.StartDate).ToString();
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
