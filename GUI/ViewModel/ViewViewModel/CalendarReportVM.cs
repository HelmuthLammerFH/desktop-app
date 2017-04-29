using DataLayer;
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
    public class CalendarReportVM : ViewModelBase
    {
        #region ATTRIBUTES
        private ObservableCollection<TourEntityVM> tourEntitieList = new ObservableCollection<TourEntityVM>();
        private TourEntityVM selectedTourEntitie;
        private DataProvider dp;
        #endregion

        #region PROPERTIES
        public RelayCommand ListReportBtn { get; set; }
        public RelayCommand TourBtn { get; set; }
        public RelayCommand PositionsBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
        public ObservableCollection<TourEntityVM> TourEntitieList
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
        public TourEntityVM SelectedTourEntitie
        {
            get
            {
                return selectedTourEntitie;
            }

            set
            {
                selectedTourEntitie = value;
                MessengerInstance.Send<TourEntityVM>(selectedTourEntitie);
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
            }
        }
        #endregion

        #region CONSTRUCTORS
        public CalendarReportVM()
        {
            //Load From DataProvider all TourEntities in TourEntitieList
            /*foreach (Tour tour in dp.QueryAllTours)
            {
                TourEntitieList.Add(new TourEntityVM(tour));
            }*/

            //Navigation Commands
            ListReportBtn = new RelayCommand(SwitchToListReport);
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);

            MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }
        #endregion

        #region NAVIGATIONCOMMANDMETHODS
        private void SwitchToListReport()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<ListReportVM>()));
        }

        private void SwitchToMember()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<MemberVM>()));
        }

        private void SwitchToPositions()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourPositionsVM>()));
        }

        private void SwitchToTour()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
        }
        #endregion
        #region GENERALCOMMANDMETHODS

        #endregion
        #region METHODS
        private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
        }
        #endregion
    }
}
