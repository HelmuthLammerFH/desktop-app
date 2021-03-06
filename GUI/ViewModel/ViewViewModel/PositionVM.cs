﻿using DataLayer;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.EntityViewModel;
using Shared.DummyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GUI.ViewModel.ViewViewModel
{
    public class PositionVM : ViewModelBase
    {
        #region ATTRIBUTES
        private KeyValueConfigurationCollection confCollection;
        private PositionEntityVM currentPositionEntity;
        //private DataProvider dp;
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
            Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            confCollection = configManager.AppSettings.Settings;
            //MessengerInstance.Register<DataProvider>(this, UpdateDataProvider);
        }
        #endregion

        #region NAVIGATIONCOMMANDMETHODS
        private void SwitchToTour()
        {
            MessengerInstance.Send<ViewModelBase>((SimpleIoc.Default.GetInstance<TourVM>()));
        }
        #endregion
        #region GENERALCOMMANDPROPERTIES
        #endregion
        #region METHODS
        private void UpdateCurrentPositionEntity(PositionEntityVM obj)
        {
            CurrentPositionEntity = obj;
            if(String.IsNullOrEmpty(CurrentPositionEntity.Description))
            {
                CurrentPositionEntity.Description = confCollection[CurrentPositionEntity.Title].Value;
                CurrentPositionEntity.GPSPosition = confCollection[CurrentPositionEntity.Title + "-Location"].Value;
            }
        }
        /**private void UpdateDataProvider(DataProvider obj)
        {
            dp = obj;
        }**/
        #endregion
    }
}
