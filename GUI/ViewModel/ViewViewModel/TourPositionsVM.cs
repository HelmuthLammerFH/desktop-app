using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using Shared.DummyEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private DataHandler datahandler;
        #endregion

        #region NAVIGATIONCOMMANDPROPERTIES
        public RelayCommand TourBtn { get; set; }
        public RelayCommand PositionsBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
        #endregion
        #region GENERALCOMMANDPROPERTIES
        public RelayCommand DeletePositionBtn { get; set; }
        public RelayCommand SavePositionBtn { get; set; }

        public RelayCommand AddPositionToTour { get; set; }

        public ObservableCollection<string> PositionList { get; set; }
        public List<PositionEntityVM> PositionEntityList { get; set; }
        public int SelectedPosition { get; set; }
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
            CreatedOrUpdatedPositionItem = new PositionEntityVM(new DummyPosition());
            TourEntityIsChoosen = Visibility.Hidden;
            //Navigation Commands
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
            //General Commands
            DeletePositionBtn = new RelayCommand(DeletePosition, CanExecuteDeletePosition);
            SavePositionBtn = new RelayCommand(SavePosition, CanExecuteSavePosition);
            datahandler = new DataHandler();
            PositionList = new ObservableCollection<string>();
            PositionEntityList = new List<PositionEntityVM>();
            foreach (var item in datahandler.GetAllPositions())
            {
                PositionList.Add(item.Title);
                PositionEntityList.Add(new PositionEntityVM(item));
            }
            AddPositionToTour = new RelayCommand(AddPosition);
            MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
            //MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }

        private void AddPosition()
        {
            var position = PositionEntityList[SelectedPosition];
            datahandler.InsertPosition(CurrentTourEntity.Tour.ID, position.TourPosition.PositionID, DateTime.Now, DateTime.Now);
            CurrentTourEntity.Positions.Add(position);
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
            if(SelectedPositionItem != null)
            {
                return true;
            }else
            {
                return false;
            }
        }

        private void SavePosition()
        {
            /**if (CreatedOrUpdatedPositionItem.TourPosition.PositionID == new Guid() && SelectedPositionItem != CreatedOrUpdatedPositionItem)
            {
               // CurrentTourEntity.Positions.Add(CreatedOrUpdatedPositionItem);
            }else
            {
                PositionEntityVM positionToRemove = new PositionEntityVM(new DummyPosition());
                foreach (PositionEntityVM position in CurrentTourEntity.Positions)
                {
                    if (position.TourPosition.PositionID == CreatedOrUpdatedPositionItem.TourPosition.PositionID)
                        positionToRemove = position;
                }
                /**CurrentTourEntity.Positions.Remove(positionToRemove);
                CurrentTourEntity.Positions.Add(CreatedOrUpdatedPositionItem);
            }**/
            CreatedOrUpdatedPositionItem = new PositionEntityVM(new DummyPosition());
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            //dp.UpdateTour(CurrentTourEntity.Tour);
            //MessengerInstance.Send<DataProvider>(dp);
        }

        private bool CanExecuteDeletePosition()
        {
            if (SelectedPositionItem != null)
                return true;
            return false;
        }

        private void DeletePosition()
        {
            /**CurrentTourEntity.Positions.Remove(SelectedPositionItem);
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            dp.UpdateTour(CurrentTourEntity.Tour);
            MessengerInstance.Send<DataProvider>(dp);**/
            var position = PositionEntityList[SelectedPosition];
            datahandler.DeletePosition(CurrentTourEntity.Tour.ID, position.TourPosition.PositionID);
            CurrentTourEntity.Positions.Remove(position);
        }

       /** private bool CanExecuteUpdatePosition()
        {
            if (SelectedPositionItem != null)
                return true;
            return false;
        }
        private void UpdatePosition()
        {
            CreatedOrUpdatedPositionItem = SelectedPositionItem;
        }**/
        #endregion
        #region METHODS
        private void UpdateDataProvider(DataProvider obj)
        {
            /**dp = obj;
            if (dp != null && CurrentTourEntity != null && !dp.QueryAllTours().Contains(CurrentTourEntity.Tour))
                CurrentTourEntity = null;**/
        }
        private void UpdateCurrentTourEntity(TourEntityVM obj)
        {
            CurrentTourEntity = obj;
        }

        
        #endregion
    }
}
