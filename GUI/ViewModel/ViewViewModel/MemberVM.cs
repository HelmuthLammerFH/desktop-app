using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.ViewModel.ViewViewModel
{
    public class MemberVM : ViewModelBase
    {
        #region ATTRIBUTES
        private TourEntityVM currentTourEntity;
        private Visibility tourEntityIsEmty;
        private Visibility tourEntityIsChoosen;
        private DataProvider dp;
        private bool update = false;
        const string loginCredentialsFilePath = "loginCredentials.csv";
        #endregion

        #region NAVIGATIONCOMMANDPROPERTIES
        public RelayCommand TourBtn { get; set; }
        public RelayCommand PositionsBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
        public RelayCommand LogoutBtn { get; set; }
        public TourEntityVM CurrentTourEntity
        {
            get
            {
                return currentTourEntity;
            }

            set
            {
                currentTourEntity = value;
                if (currentTourEntity == null)
                {
                    TourEntityIsChoosen = Visibility.Hidden;
                }
                else
                {
                    TourEntityIsChoosen = Visibility.Visible;
                    if (update == false)
                    {
                        //dp.UpdateTour(CurrentTourEntity.Tour);
                        MessengerInstance.Send<DataProvider>(dp);
                        MessengerInstance.Send<TourEntityVM>(currentTourEntity);
                    }                
                }
                RaisePropertyChanged();
            }
        }

        public RelayCommand EditBtn { get; set; }
        private DataHandler datahandler;
        #endregion
        #region GENERALCOMMANDPROPERTIES

        #endregion
        #region PROPERTIES
        public Visibility TourEntityIsEmty
        {
            get
            {
                return tourEntityIsEmty;
            }

            set
            {
                tourEntityIsEmty = value;
                RaisePropertyChanged();
            }
        }
        public Visibility TourEntityIsChoosen
        {
            get
            {
                return tourEntityIsChoosen;
            }

            set
            {
                tourEntityIsChoosen = value;
                if (tourEntityIsChoosen == Visibility.Hidden)
                {
                    TourEntityIsEmty = Visibility.Visible;
                }
                else
                {
                    TourEntityIsEmty = Visibility.Hidden;
                }
                RaisePropertyChanged();
            }
        }
        #endregion


        #region CONSTRUCTORS
        public MemberVM()
        {
            TourEntityIsChoosen = Visibility.Hidden;

            //Navigation Commands
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
            EditBtn = new RelayCommand(EditMember);
            LogoutBtn = new RelayCommand(SwitchToLogout);

            datahandler = new DataHandler();
            MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
            MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }

        private void SwitchToLogout()
        {
            File.Delete(loginCredentialsFilePath);
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<LoginVM>()));
        }

        private void EditMember()
        {
            foreach (var item in CurrentTourEntity.Members)
            {
                int participated = 1;
                if (item.Member.AttendTour)
                {
                    participated = 0;
                }else
                {
                    participated = 1;
                }
                datahandler.UpdateMembers(CurrentTourEntity.Tour.ID, item.Member.MemberID, participated);
            }
        }
        #endregion

        #region NAVIGATIONCOMMANDMETHODS
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
        private void UpdateCurrentTourEntity(TourEntityVM obj)
        {
            update = true;
            CurrentTourEntity = obj;
            update = false;
        }
        #endregion    
    }
}
