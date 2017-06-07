using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using ServiceLayer;
using Shared.Entities;
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
        private DataHandler dh;
        const string loginCredentialsFilePath = "loginCredentials.csv";
        private string statusMessage = "";
        private MessageHandler messages;
        #endregion

        #region PROPERTIES
        public RelayCommand<PasswordBox> LoginBtn { get; set; }

        public bool AngemeldetBleiben { get; set; }

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; RaisePropertyChanged(); }
        }
        private string passwort;

        public string Passwort
        {
            get { return passwort; }
            set { passwort = value; RaisePropertyChanged(); }
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
            dh = new DataHandler();
            Username = "";
            Passwort = "";
            LoginBtn = new RelayCommand<PasswordBox>(Login, CanExecuteLogin);
            AngemeldetBleiben = true;
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
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        #endregion

        #region METHODS
        private void ShowCredentialsFalseMessage()
        {
            StatusMessage = "Username oder Passwort wurde Falsch eingegeben!";
            Thread.Sleep(2000);
            StatusMessage = "";
        }

        private void Login(PasswordBox arg)
        {
            Passwort = arg.Password;
            int id = dh.GetCredentials(Username, Passwort);
            if (id != 0)
            {
                string[] linesToSave = new string[1];
                linesToSave[0] = id +";" + Username + ";" + Passwort + ";" + AngemeldetBleiben;
                File.WriteAllLines(loginCredentialsFilePath, linesToSave);
                StatusMessage = "";
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
            }
            else
            {
                Task.Factory.StartNew(ShowCredentialsFalseMessage);
            }
        }

        private bool CanExecuteLogin(PasswordBox arg)
        {
            if (!String.IsNullOrEmpty(Username))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
