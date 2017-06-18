using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using ServiceLayer;
using Shared.DummyEntities;
using System.IO;
using System.Windows;

namespace GUI.ViewModel.ViewViewModel
{
    public class RatingVM : ViewModelBase
    {
        #region ATTRIBUTES
        const string loginCredentialsFilePath = "loginCredentials.csv";
        #endregion

        #region PROPERTIES

        private DummyRating currentRating;

        public DummyRating CurrentRating
        {
            get { return currentRating; }
            set { currentRating = value;
                RaisePropertyChanged();
            }
        }


        private DataHandler datahandler;
        private TourGuideVM currentTourGuide;
        private TourEntityVM currentTourEntity;
        private Visibility tourEntityIsEmty;
        private Visibility tourEntityIsChoosen;
        private MessageHandler message;



        #endregion
        #region NAVIGATIONCOMMANDPROPERTIES
        public RelayCommand ListReportBtn { get; set; }
        public RelayCommand CalendarReportBtn { get; set; }
        public RelayCommand TourBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
        public RelayCommand SaveBtn { get; set; }

        public RelayCommand LogoutBtn { get; set; }

        public RelayCommand PositionsBtn { get; set; }

        #endregion

        #region PROPERTIES

        private MemberEntityVM currentMember;

        public MemberEntityVM CurrentMember
        {
            get { return currentMember; }
            set {
                currentMember = value;
               CurrentRating= datahandler.GetRatingForMember(CurrentMember.Member.MemberID, CurrentTourEntity.Tour.ID);
                RaisePropertyChanged();
            }
        }

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
        #endregion

        #region CONSTRUCTORS
        public RatingVM()
        {

            datahandler = new DataHandler();
            message = new MessageHandler();
           
            //Navigation Commands
            ListReportBtn = new RelayCommand(SwitchToListReport);
            CalendarReportBtn = new RelayCommand(SwitchToCalendarReport);
            TourBtn = new RelayCommand(SwitchToTour);
          
            MemberBtn = new RelayCommand(SwitchToMember);
            SaveBtn = new RelayCommand(SaveRating);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            LogoutBtn = new RelayCommand(SwitchToLogout);

            MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
            MessengerInstance.Register<TourGuideVM>(this, UpdateCurrentTourGuide);
            MessengerInstance.Register<MemberEntityVM>(this, UpdateCurrentMember);
            //MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }

        private void SwitchToLogout()
        {
            File.Delete(loginCredentialsFilePath);
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<LoginVM>()));
        }


        private void SaveRating()
        {
            datahandler.SaveRating(CurrentRating.ID,CurrentRating.StarRating,CurrentRating.Feedback);
            message.SendRating(CurrentRating.ID, CurrentRating.StarRating, CurrentRating.Feedback);
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
            MessengerInstance.Send<MemberEntityVM>(CurrentMember);
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
        #region METHODS


        

        #endregion

        private void UpdateCurrentTourEntity(TourEntityVM obj)
        {
            CurrentTourEntity = obj;
        }
        private void UpdateCurrentTourGuide(TourGuideVM obj)
        {
            CurrentTourGuide = obj;
        }
        private void UpdateCurrentMember(MemberEntityVM obj)
        {
            CurrentMember = obj;
        }
    }
}
