using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GUI.ViewModel.ViewViewModel;
using System.ServiceModel;

namespace GUI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region ATTRIBUTES
        private ViewModelBase currentVM;
        #endregion

        #region PROPERTIES
        public ViewModelBase CurrentVM
        {
            get
            {
                return currentVM;
            }

            set
            {
                currentVM = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public MainViewModel()
        {
            SimpleIoc.Default.GetInstance<CalendarReportVM>();
            SimpleIoc.Default.GetInstance<ListReportVM>();
            SimpleIoc.Default.GetInstance<TourVM>();
            SimpleIoc.Default.GetInstance<TourListVM>();
            SimpleIoc.Default.GetInstance<PositionVM>();
            SimpleIoc.Default.GetInstance<MemberVM>();
            CurrentVM = SimpleIoc.Default.GetInstance<LoginVM>();

            MessengerInstance.Register<ViewModelBase>(this, UpdateCurrentVM);
        }
        #endregion

        #region METHODS
        private void UpdateCurrentVM(ViewModelBase obj)
        {
            CurrentVM = obj;
        }
        #endregion
    }
}