using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GUI.ViewModel.ViewViewModel
{
    public class LoginVM : ViewModelBase
    {
        #region ATTRIBUTES
        private string userName;
        private string passwort = "";
        private bool angemeldetBleiben;
        private DataProvider dp = new DataProvider();
        private string loginCredentialsFilePath = "loginCredentials.csv";
        private string statusMessage = "";
        #endregion

        #region PROPERTIES
        public RelayCommand<PasswordBox> LoginBtn { get; set; }
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

        public string StatusMessage
        {
            get
            {
                return statusMessage;
            }

            set
            {
                statusMessage = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public LoginVM()
        {
            Task.Factory.StartNew(CheckIfConnectionExists);
            LoginBtn = new RelayCommand<PasswordBox>(Login, CanExecuteLogin);
        }
        #endregion

        #region METHODS
        private void CheckIfConnectionExists()
        {
            while (true)
            {
                if (dp.ConnectionExists())
                {
                    if (StatusMessage != "Username oder Passwort wurde Falsch eingegeben!")
                        StatusMessage = "";
                }
                else
                {
                    StatusMessage = "Für den Login muss eine Internetverbindung bestehen!";
                }
                Thread.Sleep(2000);
            }
        }

        private void ShowCredentialsFalseMessage()
        {
            StatusMessage = "Username oder Passwort wurde Falsch eingegeben!";
            Thread.Sleep(2000);
            StatusMessage = "";
        }

        private void Login(PasswordBox arg)
        {
            Passwort = arg.Password;
            if (dp.Login(userName, passwort))
            {
                string[] linesToSave = new string[1];
                linesToSave[0] = userName + ";" + passwort + ";" + angemeldetBleiben;
                File.WriteAllLines(loginCredentialsFilePath, linesToSave);
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
                StatusMessage = "";
            }
            else
            {
                Task.Factory.StartNew(ShowCredentialsFalseMessage);
            }
        }

        private bool CanExecuteLogin(PasswordBox arg)
        {
            if (dp.ConnectionExists())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }
}
