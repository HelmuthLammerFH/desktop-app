using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GUI.ViewModel.ViewViewModel;
using System.ServiceModel;
using System.IO;
using DataLayer;

namespace GUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region ATTRIBUTES
        private ViewModelBase currentVM;
        private string loginCredentialsFilePath = "loginCredentials.csv";
        private DataProvider dp = new DataProvider();
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
            SimpleIoc.Default.GetInstance<CalendarReportVM>();
            SimpleIoc.Default.GetInstance<ListReportVM>();
            SimpleIoc.Default.GetInstance<TourVM>();
            SimpleIoc.Default.GetInstance<TourListVM>();
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
            MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
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
                if (loginCredentials.Split(';')[2].Equals("True") && dp.ConnectionExists() && dp.Login(loginCredentials.Split(';')[0], loginCredentials.Split(';')[1]))
                {
                    MessengerInstance.Send<DataProvider>(dp);
                    return true;
                }           
            }
            return false;
        }
        #endregion
    }
}