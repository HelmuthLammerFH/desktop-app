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
    public class TourVM : ViewModelBase
    {
        #region ATTRIBUTES
        TourEntityVM currentTourEntity;
        private Visibility tourEntityIsEmty;
        private Visibility tourEntityIsChoosen;
        private DataProvider dp;
        #endregion

        #region NAVIGATIONCOMMANDPROPERTIES
            public RelayCommand ListReportBtn { get; set; }
            public RelayCommand CalendarReportBtn { get; set; }
            public RelayCommand TourBtn { get; set; }
            public RelayCommand PositionsBtn { get; set; }
            public RelayCommand MemberBtn { get; set; }
        #endregion
        #region GENERALCOMMANDPROPERTIES
        public RelayCommand<PositionEntityVM> ShowPositionBtn { get; set; }
        public RelayCommand<PositionEntityVM> DeletePositionBtn { get; set; }
        public RelayCommand DeleteTourBtn { get; set; }
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
                TourEntityIsChoosen = Visibility.Hidden;
                //Navigation Commands
                ListReportBtn = new RelayCommand(SwitchToListReport);
                CalendarReportBtn = new RelayCommand(SwitchToCalendarReport);
                TourBtn = new RelayCommand(SwitchToTour);
                PositionsBtn = new RelayCommand(SwitchToPositions);
                MemberBtn = new RelayCommand(SwitchToMember);

                //General Commands
                ShowPositionBtn = new RelayCommand<PositionEntityVM>(ShowPosition);
                DeletePositionBtn = new RelayCommand<PositionEntityVM>(DeletePosition);
                DeleteTourBtn = new RelayCommand(DeleteTour);

                MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
                MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
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
        private void DeleteTour()
        {
            //dp.DeleteTour(CurrentTourEntity.Tour);
            MessengerInstance.Send<DataProvider>(dp);
            CurrentTourEntity = null;
        }
        private void DeletePosition(PositionEntityVM obj)
        {
            //CurrentTourEntity.Positions.Remove(obj);
            //dp.UpdateTour(CurrentTourEntity.Tour);
            MessengerInstance.Send<DataProvider>(dp);
            MessengerInstance.Send<TourEntityVM>(CurrentTourEntity);
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
        private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
        }
        #endregion
    }
}
