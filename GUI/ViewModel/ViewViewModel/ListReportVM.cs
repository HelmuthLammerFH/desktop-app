using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.ViewViewModel
{
    public class ListReportVM : ViewModelBase
    {
        #region ATTRIBUTES
        ObservableCollection<TourEntitieVM> tourEntitieList = new ObservableCollection<TourEntitieVM>();
        TourEntitieVM selectedTourEntitie;
        #endregion

        #region PROPERTIES
        public RelayCommand CalendarReportBtn { get; set; }
        public RelayCommand TourBtn { get; set; }
        public RelayCommand PositionsBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
        public TourEntitieVM SelectedTourEntitie
        {
            get
            {
                return selectedTourEntitie;
            }

            set
            {
                selectedTourEntitie = value;
                MessengerInstance.Send<TourEntitieVM>(selectedTourEntitie);
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
            }
        }
        public ObservableCollection<TourEntitieVM> TourEntitieList
        {
            get
            {
                return tourEntitieList;
            }

            set
            {
                tourEntitieList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public ListReportVM()
        {
            CalendarReportBtn = new RelayCommand(SwitchToCalendarReport);
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
        }
        #endregion

        #region METHODS
        private void SwitchToCalendarReport()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<CalendarReportVM>()));
        }

        private void SwitchToMember()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<MemberVM>()));
        }

        private void SwitchToPositions()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourListVM>()));
        }

        private void SwitchToTour()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
        }
        #endregion
    }
}
