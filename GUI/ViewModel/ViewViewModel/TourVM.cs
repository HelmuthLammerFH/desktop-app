using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using Microsoft.Win32;
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
using System.Windows.Media.Imaging;

namespace GUI.ViewModel.ViewViewModel
{
    public class TourVM : ViewModelBase
    {
        #region ATTRIBUTES
        private TourGuideVM currentTourGuide;
        TourEntityVM currentTourEntity;
        private Visibility tourEntityIsEmty;
        private Visibility tourEntityIsChoosen;
       // private DataProvider dp;
        private Visibility tourEdit;
        private DataHandler datahandler;
        private MessageHandler message;
        const string loginCredentialsFilePath = "loginCredentials.csv";

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; RaisePropertyChanged(); }
        }


        public ObservableCollection<string> StatusList { get; set; }

        public Visibility TourEdit
        {
            get { return tourEdit; }
            set { tourEdit = value; RaisePropertyChanged(); }
        }

        #endregion

        #region NAVIGATIONCOMMANDPROPERTIES
        public RelayCommand ListReportBtn { get; set; }
            public RelayCommand CalendarReportBtn { get; set; }
            public RelayCommand TourBtn { get; set; }
            public RelayCommand TourEditBtn { get; set; }
            public RelayCommand MemberBtn { get; set; }
        public RelayCommand UpdateTour { get; set; }

        public RelayCommand LogoutBtn { get; set; }

        public RelayCommand PositionsBtn { get; set; }

        public RelayCommand UploadPictureBtn { get; set; }
        #endregion
        #region GENERALCOMMANDPROPERTIES
        public RelayCommand<PositionEntityVM> ShowPositionBtn { get; set; }
        public RelayCommand<PositionEntityVM> DeletePositionBtn { get; set; }
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
                    if(currentTourEntity == null)
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
                    if(tourEntityIsChoosen == Visibility.Hidden)
                    {
                        TourEntityIsEmty = Visibility.Visible;
                    }else
                    {
                        TourEntityIsEmty = Visibility.Hidden;
                    }
                    RaisePropertyChanged();
                }
            }
        #endregion

        #region CONSTRUCTORS
        public TourVM()
        {
            datahandler = new DataHandler();
            message = new MessageHandler();
            TourEntityIsChoosen = Visibility.Hidden;
            TourEdit = Visibility.Hidden;
            StatusList = new ObservableCollection<string>();
            foreach (var item in datahandler.GetAllStatus())
            {
                StatusList.Add(item.Description);
            }
                //Navigation Commands
                ListReportBtn = new RelayCommand(SwitchToListReport);
                CalendarReportBtn = new RelayCommand(SwitchToCalendarReport);
                TourBtn = new RelayCommand(SwitchToTour);
                TourEditBtn = new RelayCommand(EditTour);
                MemberBtn = new RelayCommand(SwitchToMember);
            UpdateTour = new RelayCommand(SaveTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            UploadPictureBtn = new RelayCommand(UploadPicture);
            LogoutBtn = new RelayCommand(SwitchToLogout);

                //General Commands
                ShowPositionBtn = new RelayCommand<PositionEntityVM>(ShowPosition);
                DeletePositionBtn = new RelayCommand<PositionEntityVM>(DeletePosition);

                MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
            MessengerInstance.Register<TourGuideVM>(this, UpdateCurrentTourGuide);
            //MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }

        private void SwitchToLogout()
        {
            File.Delete(loginCredentialsFilePath);
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<LoginVM>()));
        }

        private void UploadPicture()
        {
            try
            {

     
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Bitte wählen Sie ein Bild aus";
            op.Filter = "All supported graphics|*.jpg;*.jpeg|" +
                        "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|";
            if (op.ShowDialog() == true)
            {
                FileStream fs = new FileStream(op.FileName, FileMode.Open, FileAccess.Read);
                byte[] data = new byte[fs.Length];
                fs.Read(data, 0, System.Convert.ToInt32(fs.Length));
                fs.Close();
                int? newPictureID = datahandler.SavePicture(CurrentTourEntity.Tour.ID, data);
                if (newPictureID != null)
                {
                    Ressources newPicture = new Ressources() { ID = (int)newPictureID, createdFrom = CurrentTourGuide.Username, Picture = data, ChangedFrom = "", syncedFrom = 2, Tour_id = CurrentTourEntity.Tour.ID };
                    message.SendMediaData(newPicture);
                    MessageBox.Show("Ihr Bild wurde erfolgreich hochgeladen!","Mediendaten hochladen",MessageBoxButton.OK,MessageBoxImage.Asterisk);
                }
            }
            }
            catch (Exception e)
            {
                MessageBox.Show("Das Bild konnte nicht hochgeladen werden!", "Mediendaten hochladen", MessageBoxButton.OK, MessageBoxImage.Error);
                Console.WriteLine(e.Message);
            }
        }

        private void SaveTour()
        {
            datahandler.UpdateTour(CurrentTourEntity.Tour.ID, CurrentTourEntity.Title, CurrentTourEntity.Startdate, CurrentTourEntity.Enddate, Status);
            Tour temp = new Tour() {ID = CurrentTourEntity.Tour.ID, Name = CurrentTourEntity.Title, StartDate = CurrentTourEntity.Startdate, EndDate = CurrentTourEntity.Enddate, ChangedFrom = CurrentTourGuide.Username, SyncedFrom = 2, TourGuideID = CurrentTourGuide.ID, StatusID = CurrentTourEntity.State == "In planung" ? 1 : 2 };
            message.SendTour(temp);
            TourEdit = Visibility.Hidden;
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            MessengerInstance.Send<Tuple<TourEntityVM, Boolean>>(new Tuple<TourEntityVM, Boolean>(CurrentTourEntity, true));
        }

        private void EditTour()
        {
            TourEdit = Visibility.Visible;
        }
        #endregion

        #region NAVIGATIONCOMMANDMETHODS
        private void SwitchToCalendarReport()
            {
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<CalendarReportVM>()));
            }
            private void SwitchToListReport()
            {
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<ListReportVM>()));
            }

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
        private void DeletePosition(PositionEntityVM obj)
        {
            //CurrentTourEntity.Positions.Remove(obj);
            //dp.UpdateTour(CurrentTourEntity.Tour);
            //MessengerInstance.Send<DataProvider>(dp);
            var tourPosition = new TourToPositions() { StartDate = obj.StartDate, EndDate = obj.EndDate, TourID = CurrentTourEntity.Tour.ID, DeleteFlag = true, TourpositionID = obj.TourPosition.PositionID, ChangedFrom = "TourGuide", SyncedFrom = 2, UpdatedAt = DateTime.Now };

            try
            {
                var affectedID = datahandler.DeleteTourToPositions(tourPosition);
                if (affectedID != null)
                {
                    tourPosition.ID = (int)affectedID;

                    message.DeleteTourToPosition(tourPosition);
                    CurrentTourEntity.Positions.Remove(obj);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowPosition(PositionEntityVM obj)
            {
                MessengerInstance.Send<PositionEntityVM>(obj);
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<PositionVM>()));
            }
        #endregion
        #region METHODS
        private void UpdateCurrentTourEntity(TourEntityVM obj)
        {
            CurrentTourEntity = obj;
        }
        private void UpdateCurrentTourGuide(TourGuideVM obj)
        {
            CurrentTourGuide = obj;
        }
        /**private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
        }**/
        #endregion
    }
}
