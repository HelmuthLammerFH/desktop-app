using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.ViewViewModel
{
    public class LoginVM : ViewModelBase
    {
        #region ATTRIBUTES
        private string userName;
        private string passwort;
        private bool angemeldetBleiben;
        private DataProvider dp = new DataProvider();
        #endregion

        #region PROPERTIES
        public RelayCommand LoginBtn { get; set; }
        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }
        public string Passwort
        {
            get
            {
                return passwort;
            }

            set
            {
                passwort = value;
            }
        }
        public bool AngemeldetBleiben
        {
            get
            {
                return angemeldetBleiben;
            }

            set
            {
                angemeldetBleiben = value;
            }
        }
        #endregion

        #region CONSTRUCTORS
        public LoginVM()
        {
            LoginBtn = new RelayCommand(Login, CanExecuteLogin);
        }
        #endregion

        #region METHODS
        private void Login()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
        }

        private bool CanExecuteLogin()
        {
            if(dp.Login(userName,passwort,angemeldetBleiben))
                return true;
            return false;
        }
        #endregion
    }
}
