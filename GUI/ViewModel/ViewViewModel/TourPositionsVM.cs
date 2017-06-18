using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using GUI.ViewModel.ViewViewModel;
using ServiceLayer;
using Shared.DummyEntities;
using Shared.Entities;
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
    public class TourPositionsVM : ViewModelBase
    {
        #region ATTRIBUTES

        private TourGuideVM currentTourGuide;
        private MessageHandler message;
        private TourEntityVM currentTourEntity;
        private PositionEntityVM selectedPositionItem;
        private PositionEntityVM createdOrUpdatedPositionItem;
        private Visibility tourEntityIsEmty;
        private Visibility tourEntityIsChoosen;
        private Visibility positionisSelected;
        const string loginCredentialsFilePath = "loginCredentials.csv";

        public Visibility PositionIsSelected
        {
            get { return positionisSelected; }
            set { positionisSelected = value;RaisePropertyChanged(); }
        }

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

        public RelayCommand LogoutBtn { get; set; }

        public ObservableCollection<string> PositionList { get; set; }
        public List<PositionEntityVM> PositionEntityList { get; set; }
        public int SelectedPosition { get; set; }
        #endregion
        #region PROPERTIES


        public TourGuideVM CurrentTourGuide
        {
            get { return currentTourGuide; }
            set { currentTourGuide = value; RaisePropertyChanged(); }
        }


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
                PositionIsSelected = Visibility.Visible;
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
            message = new MessageHandler();
            CreatedOrUpdatedPositionItem = new PositionEntityVM(new DummyPosition());
            TourEntityIsChoosen = Visibility.Hidden;
            PositionIsSelected = Visibility.Hidden;
            //Navigation Commands
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
            //General Commands
            DeletePositionBtn = new RelayCommand(DeletePosition, CanExecuteDeletePosition);
            SavePositionBtn = new RelayCommand(SavePosition, CanExecuteSavePosition);
            LogoutBtn = new RelayCommand(SwitchToLogout);
            datahandler = new DataHandler();
            PositionList = new ObservableCollection<string>();
            PositionEntityList = new List<PositionEntityVM>();
            foreach (var item in datahandler.GetAllPositions())
            {
                PositionList.Add(item.Title);
                PositionEntityList.Add(new PositionEntityVM(item));
            }
            AddPositionToTour = new RelayCommand(AddPosition,CanExecuteAddPosition);
            MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
            MessengerInstance.Register<TourGuideVM>(this, UpdateCurrentTourGuide);
            //MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }

        private bool CanExecuteAddPosition()
        {
            if (PositionEntityList.Count > 10)
            {
                return false;
            }
            return true;
        }

        private void SwitchToLogout()
        {
            File.Delete(loginCredentialsFilePath);
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<LoginVM>()));
        }

        private void AddPosition()
        {
            var position = PositionEntityList[SelectedPosition];
            int? newTourToPositionID = datahandler.InsertPosition(CurrentTourEntity.Tour.ID, position.TourPosition.PositionID, DateTime.Now);
            if (newTourToPositionID != null)
            {
                var newTourToPostion = new TourToPositions() { ID = (int)newTourToPositionID, CreatedFrom = CurrentTourGuide.Username, TourID = CurrentTourEntity.Tour.ID, TourpositionID = position.TourPosition.PositionID, CreatedAt = DateTime.Now, StartDate = DateTime.Now, EndDate = DateTime.Now, SyncedFrom = 2 };
                message.SendTourToPositionen(newTourToPostion);
            }
            //Das heutige Datum setzen, sodass ein default Wert in der Liste drinnen steht und kein ungültiger Wert als Datum
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

           var tourPosition = new TourToPositions() {StartDate = SelectedPositionItem.StartDate, EndDate = SelectedPositionItem.EndDate, TourID = CurrentTourEntity.Tour.ID, TourpositionID = SelectedPositionItem.TourPosition.PositionID, ChangedFrom = CurrentTourGuide.Username,  SyncedFrom = 2, UpdatedAt = DateTime.Now };
            var affectedID = datahandler.UpdateTourToPositions(tourPosition);
            if (affectedID != null)
            {
                tourPosition.ID = (int)affectedID;
                // Schnittstelle kann kein Update
                message.UpdateTourToPosition(tourPosition);
            }

            //MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
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
            var tourPosition = new TourToPositions() { StartDate = SelectedPositionItem.StartDate, EndDate = SelectedPositionItem.EndDate, TourID = CurrentTourEntity.Tour.ID, DeleteFlag=true, TourpositionID = SelectedPositionItem.TourPosition.PositionID, ChangedFrom = CurrentTourGuide.Username, SyncedFrom = 2, UpdatedAt = DateTime.Now };

            try
            {
                var affectedID = datahandler.DeleteTourToPositions(tourPosition);
                if (affectedID != null)
                {
                    tourPosition.ID = (int)affectedID;
                   
                    message.DeleteTourToPosition(tourPosition);
                    CurrentTourEntity.Positions.Remove(SelectedPositionItem);
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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

        private void UpdateCurrentTourGuide(TourGuideVM obj)
        {
            CurrentTourGuide = obj;
        }
        #endregion
    }
}
