using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using System;
using System.Collections.Generic;
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
        #endregion

        #region CONSTRUCTORS
        public TourPositionsVM()
        {
            //CreatedOrUpdatedPositionItem = new PositionEntityVM(new Position());
            TourEntityIsChoosen = Visibility.Hidden;
            //Navigation Commands
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
            //General Commands
            UpdatePositionBtn = new RelayCommand(UpdatePosition, CanExecuteUpdatePosition);
            DeletePositionBtn = new RelayCommand(DeletePosition, CanExecuteDeletePosition);
            SavePositionBtn = new RelayCommand(SavePosition, CanExecuteSavePosition);

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
        private bool CanExecuteSavePosition()
        {
            //if (CreatedOrUpdatedPositionItem.Bezeichnung != "")
                return true;
            //return false;
        }
        private void SavePosition()
        {
            /*if (CreatedOrUpdatedPositionItem.Id == null)
            {
                CurrentTourEntity.Positionen.Add(CreatedOrUpdatedPositionItem);
            }else
            {
                PositionEntityVM positionToRemove;
                foreach (PositionEntityVM position in CurrentTourEntity.Positionen)
                {
                    if (position.Id == CreatedOrUpdatedPositionItem.Id)
                        positionToRemove = position;
                }
                CurrentTourEntity.Positionen.Remove(positionToRemove);
                CurrentTourEntity.Positionen.Add(CreatedOrUpdatedPositionItem);
            }
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            dp.UpdateTour(CurrentTourEntity.Tour);
            MessengerInstance.Send<DataProvider>(dp);*/
        }

        private bool CanExecuteDeletePosition()
        {
            if (SelectedPositionItem != null)
                return true;
            return false;
        }

        private void DeletePosition()
        {
            //CurrentTourEntity.Positionen.Remove(SelectedPositionItem);
            //MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            //dp.UpdateTour(CurrentTourEntity.Tour);
            //MessengerInstance.Send<DataProvider>(dp);
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
        }
        #endregion
        #region METHODS
        private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
        }
        private void UpdateCurrentTourEntity(TourEntityVM obj)
        {
            CurrentTourEntity = obj;
        }

        
        #endregion
    }
}
