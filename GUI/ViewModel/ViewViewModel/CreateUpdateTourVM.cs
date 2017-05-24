using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using Shared.DummyEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.ViewViewModel
{
    public class CreateUpdateTourVM : ViewModelBase
    {
        #region ATTRIBUTES
        private TourEntityVM currentTourEntity;
        private DataProvider dp;
        private ObservableCollection<TourGuideEntityVM> tourGuideList = new ObservableCollection<TourGuideEntityVM>();
        private ObservableCollection<string> stateList = new ObservableCollection<string>();
        private string selectedState;
        private TourGuideEntityVM selectedTourGuide;
        private int minute;
        private int hour;
        #endregion

        #region NAVIGATIONCOMMANDPROPERTIES
        public RelayCommand TourBtn { get; set; }
        #endregion
        #region GENERALCOMMANDPROPERTIES
        public RelayCommand SaveBtn { get; set; }
        #endregion
        #region PROPERTIES
        public TourEntityVM CurrentTourEntity
        {
            get
            {
                return currentTourEntity;
            }

            set
            {
                currentTourEntity = value;
                if (CurrentTourEntity != null)
                {
                    Minute = CurrentTourEntity.Date.Minute;
                    Hour = CurrentTourEntity.Date.Hour;
                    SelectedState = CurrentTourEntity.State;
                }
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<TourGuideEntityVM> TourGuideList
        {
            get
            {
                return tourGuideList;
            }

            set
            {
                tourGuideList = value;
                RaisePropertyChanged();
            }
        }

        public TourGuideEntityVM SelectedTourGuide
        {
            get
            {
                return selectedTourGuide;
            }

            set
            {
                selectedTourGuide = value;
                if(SelectedTourGuide != null)
                    CurrentTourEntity.TourGuide = SelectedTourGuide;
                RaisePropertyChanged();
            }
        }

        public int Minute
        {
            get
            {
                return minute;
            }

            set
            {
                minute = value;
                DateTime newDate = new DateTime(CurrentTourEntity.Date.Year, CurrentTourEntity.Date.Month, CurrentTourEntity.Date.Day, CurrentTourEntity.Date.Hour, Minute, CurrentTourEntity.Date.Second);
                CurrentTourEntity.Date = newDate;
                RaisePropertyChanged();
            }
        }

        public int Hour
        {
            get
            {
                return hour;
            }

            set
            {
                hour = value;
                DateTime newDate = new DateTime(CurrentTourEntity.Date.Year, CurrentTourEntity.Date.Month, CurrentTourEntity.Date.Day, Hour, CurrentTourEntity.Date.Minute, CurrentTourEntity.Date.Second);
                CurrentTourEntity.Date = newDate;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<string> StateList
        {
            get
            {
                return stateList;
            }

            set
            {
                stateList = value;
                RaisePropertyChanged();
            }
        }

        public string SelectedState
        {
            get
            {
                return selectedState;
            }

            set
            {
                selectedState = value;
                if(CurrentTourEntity != null)
                    CurrentTourEntity.State = SelectedState;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public CreateUpdateTourVM()
        {
            StateList.Add("offen");
            StateList.Add("läuft");
            StateList.Add("beendet");
            //Navigation Commands
            TourBtn = new RelayCommand(SwitchToTour);
            //General Commands
            SaveBtn = new RelayCommand(SaveTour, CanExecuteSaveTour);

            MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
            MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }
        #endregion

        #region NAVIGATIONCOMMANDMETHODS
        private void SwitchToTour()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
        }
        #endregion
        #region GENERALCOMMANDMETHODS
        private bool CanExecuteSaveTour()
        {
            if(CurrentTourEntity != null && CurrentTourEntity.Title != "")
                return true;
            return false;
        }
        private void SaveTour()
        {
            if (CurrentTourEntity.Tour.TourID == new Guid())
            {
                CurrentTourEntity.Positions = new ObservableCollection<PositionEntityVM>();
                CurrentTourEntity.Members = new ObservableCollection<MemberEntityVM>();
                dp.SaveTour(CurrentTourEntity.Tour);
            }else
            {
                dp.UpdateTour(CurrentTourEntity.Tour);
            }
            MessengerInstance.Send<DataProvider>(dp);
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            SwitchToTour();
        }
        #endregion
        #region METHODS
        private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
            if(dp != null)
            {
                TourGuideList.Clear();
                foreach (DummyTourGuide tourGuide in dp.QueryAllTourGuides())
                {
                    TourGuideList.Add(new TourGuideEntityVM(tourGuide));
                }
            }
            if (dp != null && CurrentTourEntity != null && !dp.QueryAllTours().Contains(CurrentTourEntity.Tour))              
                CurrentTourEntity = null;

        }
        private void UpdateCurrentTourEntity(TourEntityVM obj)
        {
            CurrentTourEntity = obj;
            if(CurrentTourEntity == null)
            {
                CurrentTourEntity = new TourEntityVM(new Shared.DummyEntities.DummyTour() { Date = DateTime.Now });
                if(TourGuideList.Count > 0)
                    SelectedTourGuide = TourGuideList[0];
                SelectedState = "offen";
            }
            else
            {
                foreach(TourGuideEntityVM tourGuide in TourGuideList)
                {
                    if(tourGuide.TourGuide.TourGuideID == CurrentTourEntity.TourGuide.TourGuide.TourGuideID)
                    {
                        SelectedTourGuide = tourGuide;
                        break;
                    }
                }
                
            }
        }
        #endregion
    }
}
