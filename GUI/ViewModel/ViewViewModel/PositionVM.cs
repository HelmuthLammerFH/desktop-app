using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.ViewModel.ViewViewModel
{
    public class PositionVM : ViewModelBase
    {
        #region ATTRIBUTES
        PositionEntityVM currentPositionEntity;
        #endregion

        #region PROPERTIES
        public RelayCommand TourBtn { get; set; }
        public PositionEntityVM CurrentPositionEntity
        {
            get
            {
                return currentPositionEntity;
            }

            set
            {
                currentPositionEntity = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CONSTRUCTORS
        public PositionVM()
        {
            TourBtn = new RelayCommand(SwitchToTour);
            MessengerInstance.Register<PositionEntityVM>(this, UpdateCurrentPositionEntity);
        }
        #endregion

        #region METHODS
        private void UpdateCurrentPositionEntity(PositionEntityVM obj)
        {
            CurrentPositionEntity = obj;
        }
        private void SwitchToTour()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
        }
        #endregion
    }
}
