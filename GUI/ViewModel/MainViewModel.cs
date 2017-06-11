using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GUI.ViewModel.ViewViewModel;
using System.ServiceModel;
using System.IO;
using DataLayer;
using ServiceLayer;

namespace GUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region ATTRIBUTES
        private ViewModelBase currentVM;
        private string loginCredentialsFilePath = "loginCredentials.csv";
        private DataProvider dp = new DataProvider();
        private MessageHandler messages;
        private DataHandler dh;
        #endregion

        #region PROPERTIES
        public ViewModelBase CurrentVM
        {
            get
            {
                return currentVM;
            }

            set
            {
                currentVM = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public MainViewModel()
        {

            dh = new DataHandler();
            //prepare Connection to Backend
            messages = new MessageHandler();
            //prepare Database
            try
            {
                foreach (var item in messages.GetAllUsers())
                {
                    dh.InsertUsers(item);
                }
                foreach (var item in messages.GetAllCustomers())
                {
                    dh.InsertCustomer(item);
                }
                foreach (var item in messages.GetAllTourGuides())
                {
                    dh.InsertTourGuides(item);
                }
                foreach (var item in messages.GetAllStatuse())
                {
                    dh.InsertStatus(item);
                }
                foreach (var item in messages.GetAllTours())
                {
                    dh.InsertTour(item);
                }
                foreach (var item in messages.GetAllPositions())
                {
                    dh.InsertTourPosition(item);
                }
                foreach (var item in messages.GetAllToursToPosition())
                {
                    dh.InsertTourToPositions(item);
                }
                foreach (var item in messages.GetAllCustomersToTour())
                {
                    dh.InsertCustomerToTours(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            SimpleIoc.Default.GetInstance<CalendarReportVM>();
            SimpleIoc.Default.GetInstance<ListReportVM>();
            SimpleIoc.Default.GetInstance<TourVM>();
            SimpleIoc.Default.GetInstance<TourPositionsVM>();
            SimpleIoc.Default.GetInstance<PositionVM>();
            SimpleIoc.Default.GetInstance<MemberVM>();

            if (Angemeldet())
            {
                CurrentVM = SimpleIoc.Default.GetInstance<TourVM>();
            }
            else
            {
                CurrentVM = SimpleIoc.Default.GetInstance<LoginVM>();
            }

            MessengerInstance.Register<ViewModelBase>(this, UpdateCurrentVM);
           // MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }
        #endregion

        #region METHODS
        private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
        }
        private void UpdateCurrentVM(ViewModelBase obj)
        {
            CurrentVM = obj;
        }
        private bool Angemeldet()
        {
            if (File.Exists(loginCredentialsFilePath))
            {
                string loginCredentials = File.ReadAllLines(loginCredentialsFilePath)[0];
                if (loginCredentials.Split(';')[3].Equals("True"))
                {
                    //MessengerInstance.Send<DataProvider>(dp);
                    return true;
                }           
            }
            return false;
        }
        #endregion
    }
}