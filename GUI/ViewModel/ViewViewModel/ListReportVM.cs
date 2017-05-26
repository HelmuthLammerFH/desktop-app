using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using Shared.DummyEntities;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.ViewViewModel
{
    public class ListReportVM : ViewModelBase
    {
        #region ATTRIBUTES
        private ObservableCollection<TourEntityVM> tourEntitieList = new ObservableCollection<TourEntityVM>();
        private TourEntityVM selectedTourEntitie;
        const string loginCredentialsFilePath = "loginCredentials.csv";
        private DataHandler datahandler;
        #endregion

        #region PROPERTIES
        public RelayCommand CalendarReportBtn { get; set; }
        public RelayCommand TourBtn { get; set; }
        public RelayCommand PositionsBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
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
        #endregion

        #region CONSTRUCTORS
        public ListReportVM()
        {
            datahandler = new DataHandler();
            //Navigation Commands
            CalendarReportBtn = new RelayCommand(SwitchToCalendarReport);
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
            ReadToursFromGuide();
            //MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }
        #endregion

        #region NAVIGATIONCOMMANDMETHODS
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
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourPositionsVM>()));
        }

        private void SwitchToTour()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
        }

        private void ReadToursFromGuide()
        {
            if (File.Exists(loginCredentialsFilePath))
            {
                string loginCredentials = File.ReadAllLines(loginCredentialsFilePath)[0];
                foreach (var item in datahandler.GetAllToursByGuide(Int16.Parse(loginCredentials.Split(';')[0])))
                {
                    TourEntitieList.Add(new TourEntityVM(item));
                }
            }
        }
        #endregion
        #region GENERALCOMMANDMETHODS

        #endregion
        #region METHODS
        /**private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
           List<Tour> tours = new List<Tour>();
            foreach (var item in datahandler.GetAllTours())
            {
                tours.Add(new Tour() {ID = item.ID });
            }*
            //Load From DataProvider all TourEntities in TourEntitieList
            TourEntitieList.Clear();
            foreach (DummyTour tour in obj.QueryAllTours())
            {
                TourEntitieList.Add(new TourEntityVM(tour));
            }
        }**/
        #endregion
    }
}
