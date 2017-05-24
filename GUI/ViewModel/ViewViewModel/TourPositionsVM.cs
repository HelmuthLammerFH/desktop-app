using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using Shared.DummyEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI.ViewModel.ViewViewModel
{
    public class TourPositionsVM : ViewModelBase
    {
        #region ATTRIBUTES
        private TourEntityVM currentTourEntity;
        private PositionEntityVM selectedPositionItem;
        private PositionEntityVM createdOrUpdatedPositionItem;
        private Visibility tourEntityIsEmty;
        private Visibility tourEntityIsChoosen;
        private DataProvider dp;
        private int fromMinute;
        private int fromHour;
        private int toMinute;
        private int toHour;
        public DateTime fromDate;
        #endregion

        #region NAVIGATIONCOMMANDPROPERTIES
        public RelayCommand TourBtn { get; set; }
        public RelayCommand PositionsBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
        #endregion
        #region GENERALCOMMANDPROPERTIES
        public RelayCommand UpdatePositionBtn { get; set; }
        public RelayCommand DeletePositionBtn { get; set; }
        public RelayCommand SavePositionBtn { get; set; }
        public RelayCommand SynchroniesBtn { get; set; }
        public RelayCommand LogoutBtn { get; set; }
        #endregion
        #region PROPERTIES
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
                }
                RaisePropertyChanged();
            }
        }
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
        public PositionEntityVM SelectedPositionItem
        {
            get
            {
                return selectedPositionItem;
            }

            set
            {
                selectedPositionItem = value;
                RaisePropertyChanged();
            }
        }
        public PositionEntityVM CreatedOrUpdatedPositionItem
        {
            get
            {
                return createdOrUpdatedPositionItem;
            }

            set
            {
                createdOrUpdatedPositionItem = value;
                RaisePropertyChanged();
            }
        }

        public int FromMinute
        {
            get
            {
                return fromMinute;
            }

            set
            {
                fromMinute = value;
                DateTime newDate = new DateTime(CreatedOrUpdatedPositionItem.FromDateTime.Year, CreatedOrUpdatedPositionItem.FromDateTime.Month, CreatedOrUpdatedPositionItem.FromDateTime.Day, CreatedOrUpdatedPositionItem.FromDateTime.Hour, FromMinute, CreatedOrUpdatedPositionItem.FromDateTime.Second);
                CreatedOrUpdatedPositionItem.FromDateTime = newDate;
                RaisePropertyChanged();
            }
        }
        public int FromHour
        {
            get
            {
                return fromHour;
            }

            set
            {
                fromHour = value;
                DateTime newDate = new DateTime(CreatedOrUpdatedPositionItem.FromDateTime.Year, CreatedOrUpdatedPositionItem.FromDateTime.Month, CreatedOrUpdatedPositionItem.FromDateTime.Day, FromHour, CreatedOrUpdatedPositionItem.FromDateTime.Minute, CreatedOrUpdatedPositionItem.FromDateTime.Second);
                CreatedOrUpdatedPositionItem.FromDateTime = newDate;
                RaisePropertyChanged();
            }
        }
        public int ToMinute
        {
            get
            {
                return toMinute;
            }

            set
            {
                toMinute = value;
                DateTime newDate = new DateTime(CreatedOrUpdatedPositionItem.FromDateTime.Year, CreatedOrUpdatedPositionItem.FromDateTime.Month, CreatedOrUpdatedPositionItem.FromDateTime.Day, CreatedOrUpdatedPositionItem.FromDateTime.Hour, ToMinute, CreatedOrUpdatedPositionItem.FromDateTime.Second);
                CreatedOrUpdatedPositionItem.FromDateTime = newDate;
                RaisePropertyChanged();
            }
        }
        public int ToHour
        {
            get
            {
                return toHour;
            }

            set
            {
                toHour = value;
                DateTime newDate = new DateTime(CreatedOrUpdatedPositionItem.FromDateTime.Year, CreatedOrUpdatedPositionItem.FromDateTime.Month, CreatedOrUpdatedPositionItem.FromDateTime.Day, ToHour, CreatedOrUpdatedPositionItem.FromDateTime.Minute, CreatedOrUpdatedPositionItem.FromDateTime.Second);
                CreatedOrUpdatedPositionItem.FromDateTime = newDate;
                RaisePropertyChanged();
            }
        }
        public DateTime FromDate
        {
            get
            {
                return fromDate;
            }

            set
            {
                fromDate = value;
                CreatedOrUpdatedPositionItem.FromDateTime = FromDate;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public TourPositionsVM()
        {
            CreatedOrUpdatedPositionItem = new PositionEntityVM(new DummyPosition() { FromDateTime = DateTime.Now, ToDateTime = DateTime.Now });
            TourEntityIsChoosen = Visibility.Hidden;
            //Navigation Commands
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
            //General Commands
            UpdatePositionBtn = new RelayCommand(UpdatePosition, CanExecuteUpdatePosition);
            DeletePositionBtn = new RelayCommand(DeletePosition, CanExecuteDeletePosition);
            SavePositionBtn = new RelayCommand(SavePosition, CanExecuteSavePosition);
            SynchroniesBtn = new RelayCommand(Synchronies, CanExecuteSynchronies);
            LogoutBtn = new RelayCommand(Logout);

            MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
            MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
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
        private void Logout()
        {
            if (File.Exists("loginCredentials.csv"))
                File.Delete("loginCredentials.csv");
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<LoginVM>()));
        }

        private bool CanExecuteSynchronies()
        {
            if (dp != null && dp.ConnectionExists())
                return true;
            return false;
        }

        private void Synchronies()
        {
            dp.Synchronies();
            MessengerInstance.Send<DataProvider>(dp);
        }
        private bool CanExecuteSavePosition()
        {
            if (CreatedOrUpdatedPositionItem.Title != "")
                return true;
            return false;
        }
        private void SavePosition()
        {
            if (CreatedOrUpdatedPositionItem.TourPosition.PositionID == new Guid() && SelectedPositionItem != CreatedOrUpdatedPositionItem)
            {
                CurrentTourEntity.Positions.Add(CreatedOrUpdatedPositionItem);
            }else
            {
                PositionEntityVM positionToRemove = new PositionEntityVM(new DummyPosition());
                foreach (PositionEntityVM position in CurrentTourEntity.Positions)
                {
                    if (position.TourPosition.PositionID == CreatedOrUpdatedPositionItem.TourPosition.PositionID)
                        positionToRemove = position;
                }
                CurrentTourEntity.Positions.Remove(positionToRemove);
                CurrentTourEntity.Positions.Add(CreatedOrUpdatedPositionItem);
            }
            CreatedOrUpdatedPositionItem = new PositionEntityVM(new DummyPosition() { FromDateTime = DateTime.Now, ToDateTime = DateTime.Now });
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            dp.UpdateTour(CurrentTourEntity.Tour);
            MessengerInstance.Send<DataProvider>(dp);
        }

        private bool CanExecuteDeletePosition()
        {
            if (SelectedPositionItem != null)
                return true;
            return false;
        }

        private void DeletePosition()
        {
            CurrentTourEntity.Positions.Remove(SelectedPositionItem);
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            dp.UpdateTour(CurrentTourEntity.Tour);
            MessengerInstance.Send<DataProvider>(dp);
        }

        private bool CanExecuteUpdatePosition()
        {
            if (SelectedPositionItem != null)
                return true;
            return false;
        }
        private void UpdatePosition()
        {
            CreatedOrUpdatedPositionItem = SelectedPositionItem;
            FromDate = SelectedPositionItem.FromDateTime;
            FromHour = SelectedPositionItem.FromDateTime.Hour;
            FromMinute = SelectedPositionItem.FromDateTime.Minute;
            ToHour = SelectedPositionItem.ToDateTime.Hour;
            ToMinute = SelectedPositionItem.ToDateTime.Minute;
        }
        #endregion
        #region METHODS
        private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
            if (dp != null && CurrentTourEntity != null && !dp.QueryAllTours().Contains(CurrentTourEntity.Tour))
                CurrentTourEntity = null;
        }
        private void UpdateCurrentTourEntity(TourEntityVM obj)
        {
            CurrentTourEntity = obj;
        }     
        #endregion
    }
}
