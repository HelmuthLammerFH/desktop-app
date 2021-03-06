﻿using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GUI.ViewModel.EntityViewModel;
using ServiceLayer;
using Shared.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
        //private MessageHandler messages;
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
            //Passwort = GetMD5Hash(Passwort);
            int id = dh.GetCredentials(Username, Passwort);
            if (id != 0)
            {
                string[] linesToSave = new string[1];
                linesToSave[0] = id +";" + Username + ";" + Passwort + ";" + AngemeldetBleiben;
                var currentTourGuide = new TourGuideVM(id, Username);
                File.WriteAllLines(loginCredentialsFilePath, linesToSave);
                StatusMessage = "";
                SimpleIoc.Default.Reset();
                SimpleIoc.Default.Register<LoginVM>();
                SimpleIoc.Default.Register<CalendarReportVM>();
                SimpleIoc.Default.Register<ListReportVM>();
                SimpleIoc.Default.Register<TourVM>();
                SimpleIoc.Default.Register<TourPositionsVM>();
                SimpleIoc.Default.Register<PositionVM>();
                SimpleIoc.Default.Register<MemberVM>();
                SimpleIoc.Default.Register<RatingVM>();
                SimpleIoc.Default.Register<MainViewModel>();


                SimpleIoc.Default.GetInstance<CalendarReportVM>();
                SimpleIoc.Default.GetInstance<ListReportVM>();
                SimpleIoc.Default.GetInstance<TourVM>();
                SimpleIoc.Default.GetInstance<TourPositionsVM>();
                SimpleIoc.Default.GetInstance<PositionVM>();
                SimpleIoc.Default.GetInstance<MemberVM>();
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
                MessengerInstance.Send<TourGuideVM>((currentTourGuide));
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
