using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.ViewViewModel
{
    public class TourVM : ViewModelBase
    {
        #region ATTRIBUTES
        #endregion

        #region PROPERTIES
        public RelayCommand ListReportBtn { get; set; }
        public RelayCommand CalendarReportBtn { get; set; }
        public RelayCommand TourBtn { get; set; }
        public RelayCommand PositionsBtn { get; set; }
        public RelayCommand MemberBtn { get; set; }
        #endregion

        #region CONSTRUCTORS
        public TourVM()
        {
            ListReportBtn = new RelayCommand(SwitchToListReport);
            CalendarReportBtn = new RelayCommand(SwitchToCalendarReport);
            TourBtn = new RelayCommand(SwitchToTour);
            PositionsBtn = new RelayCommand(SwitchToPositions);
            MemberBtn = new RelayCommand(SwitchToMember);
        }
        #endregion

        #region METHODS
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
    }
}
