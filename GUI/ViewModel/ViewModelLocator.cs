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
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginVM>();
            SimpleIoc.Default.Register<CalendarReportVM>();
            SimpleIoc.Default.Register<ListReportVM>();
            SimpleIoc.Default.Register<TourVM>();
            SimpleIoc.Default.Register<TourListVM>();
            SimpleIoc.Default.Register<PositionVM>();
            SimpleIoc.Default.Register<MemberVM>();
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
        public TourListVM TourList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TourListVM>();
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