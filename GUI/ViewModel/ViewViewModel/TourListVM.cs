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
    public class TourListVM : ViewModelBase
    {
        #region ATTRIBUTES
        TourEntityVM currentTourEntity;
        private Visibility tourEntityIsEmty;
        private Visibility tourEntityIsChoosen;
        #endregion

        #region PROPERTIES
        public RelayCommand TourBtn { get; set; }
        public RelayCommand PositionsBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
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
        public TourListVM()
        {
            TourEntityIsChoosen = Visibility.Hidden;
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
            MessengerInstance.Register<TourEntityVM>(this, UpdateCurrentTourEntity);
        }
        #endregion

        #region METHODS
        private void UpdateCurrentTourEntity(TourEntityVM obj)
        {
            CurrentTourEntity = obj;
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
    }
}
