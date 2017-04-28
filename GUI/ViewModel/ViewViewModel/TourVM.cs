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
    public class TourVM : ViewModelBase
    {
        #region ATTRIBUTES
            TourEntityVM currentTourEntity;
            private Visibility tourEntityIsEmty;
            private Visibility tourEntityIsChoosen;
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

                MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
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
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourListVM>()));
            }

            private void SwitchToTour()
            {
                MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
            }
        #endregion
        #region GENERALCOMMANDMETHODS
            private void DeletePosition(PositionEntityVM obj)
            {
                //Lösche Position
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
        #endregion
    }
}
