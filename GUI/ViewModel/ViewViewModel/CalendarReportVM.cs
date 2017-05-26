using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using Shared.DummyEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        const string loginCredentialsFilePath = "loginCredentials.csv";
        private DataHandler datahandler;
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
            //Navigation Commands
            datahandler = new DataHandler();
            ListReportBtn = new RelayCommand(SwitchToListReport);
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
            ReadToursFromGuide();
            //MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
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
        /**private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
            //Load From DataProvider all TourEntities in TourEntitieList
            TourEntitieList.Clear();
            foreach (DummyTour tour in dp.QueryAllTours())
            {
                TourEntitieList.Add(new TourEntityVM(tour));
            }
        }**/
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
    }
}
