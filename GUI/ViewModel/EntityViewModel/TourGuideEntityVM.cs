using GalaSoft.MvvmLight;
using Shared.DummyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.EntityViewModel
{
    public class TourGuideEntityVM : ViewModelBase
    {
        private DummyTourGuide tourGuide;

        public TourGuideEntityVM(DummyTourGuide tourGuide)
        {
            this.tourGuide = tourGuide;
        }

        public string PreName
        {
            get
            {
                return tourGuide.User.PreName;
            }

            set
            {
                tourGuide.User.PreName = value;
            }
        }

        public string SureName
        {
            get
            {
                return tourGuide.User.SureName;
            }

            set
            {
                tourGuide.User.SureName = value;
            }
        }

        public string FullName
        {
            get
            {
                return PreName + " " + SureName;
            }
        }

        public DummyTourGuide TourGuide
        {
            get
            {
                return tourGuide;
            }

            set
            {
                tourGuide = value;
            }
        }
    }
}
