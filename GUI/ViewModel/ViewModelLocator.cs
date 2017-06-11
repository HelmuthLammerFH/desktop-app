/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:GUI"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GUI.ViewModel.ViewViewModel;
using Microsoft.Practices.ServiceLocation;

namespace GUI.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
         
            SimpleIoc.Default.Register<LoginVM>(false);
            SimpleIoc.Default.Register<CalendarReportVM>(false);
            SimpleIoc.Default.Register<ListReportVM>(false);
            SimpleIoc.Default.Register<TourVM>(false);
            SimpleIoc.Default.Register<TourPositionsVM>(false);
            SimpleIoc.Default.Register<PositionVM>(false);
            SimpleIoc.Default.Register<MemberVM>(false);
            SimpleIoc.Default.Register<MainViewModel>(true);
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public LoginVM Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginVM>();
            }
        }
        public CalendarReportVM CalendarReport
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CalendarReportVM>();
            }
        }
        public ListReportVM ListReport
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ListReportVM>();
            }
        }
        public TourVM Tour
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TourVM>();
            }
        }
        public TourPositionsVM TourPositions
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TourPositionsVM>();
            }
        }
        public PositionVM Position
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PositionVM>();
            }
        }
        public MemberVM Member
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MemberVM>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}