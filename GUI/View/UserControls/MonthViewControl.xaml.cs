using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Globalization;
using GUI.ViewModel.EntityViewModel;
using System.Collections.ObjectModel;
using System.Linq;

namespace GUI.View.UserControls
{
    /// <summary>
    /// Interaktionslogik für MonthViewControl.xaml
    /// </summary>
    public partial class MonthViewControl : UserControl
    {

        static DateTime displayStartDate = DateTime.Now.AddDays(-1 * (DateTime.Now.Day - 1));
        private int displayMonth = displayStartDate.Month;
        private int displayYear = displayStartDate.Year;
        private static CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentUICulture.LCID);
        private System.Globalization.Calendar sysCal = cultureInfo.Calendar;

        public event DisplayMonthChangedEventHandler DisplayMonthChanged;
        public delegate void DisplayMonthChangedEventHandler(MonthChangedEventArgs e);
        public event DayBoxDoubleClickedEventHandler DayBoxDoubleClicked;
        public delegate void DayBoxDoubleClickedEventHandler(NewAppointmentEventArgs e);
        public event AppointmentDblClickedEventHandler AppointmentDblClicked;
        public delegate void AppointmentDblClickedEventHandler(int Appointment_Id);

        public static readonly DependencyProperty CustomDataSourceProperty =
        DependencyProperty.Register(
        "DataSource", typeof(ObservableCollection<TourEntityVM>), typeof(MonthViewControl),
        new FrameworkPropertyMetadata(new ObservableCollection<TourEntityVM>(),FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public ObservableCollection<TourEntityVM> DataSource
        {
            get { return (ObservableCollection<TourEntityVM>)GetValue(CustomDataSourceProperty); }
            set {

                SetValue(CustomDataSourceProperty, value);

            }
        }


        public static readonly DependencyProperty CustomSelectedTourProperty =
        DependencyProperty.Register(
        "SelectedTour", typeof(TourEntityVM), typeof(MonthViewControl),
        new FrameworkPropertyMetadata(new TourEntityVM(new Shared.DummyEntities.DummyTour()), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public TourEntityVM SelectedTour
        {
            get { return (TourEntityVM)GetValue(CustomSelectedTourProperty); }
            set
            {

                SetValue(CustomSelectedTourProperty, value);

            }
        }

        public DateTime DisplayStartDate
        {
            get { return displayStartDate; }
            set
            {
                displayStartDate = value;
                displayMonth = displayStartDate.Month;
                displayYear = displayStartDate.Year;
            }
        }

        public MonthViewControl()
        {
            Loaded += MonthView_Loaded;
            InitializeComponent();
        }

        private void MonthView_Loaded(object sender, RoutedEventArgs e)
        {
                BuildCalendarUI();
        }

        private void BuildCalendarUI()
        {
            int iDaysInMonth = sysCal.GetDaysInMonth(displayStartDate.Year, displayStartDate.Month);
            int iOffsetDays = Convert.ToInt32(System.Enum.ToObject(typeof(System.DayOfWeek), displayStartDate.DayOfWeek));
            int iWeekCount = 0;
            WeekOfDaysControl weekRowCtrl = new WeekOfDaysControl();

            MonthViewGrid.Children.Clear();
            AddRowsToMonthGrid(iDaysInMonth, iOffsetDays);
            MonthYearLabel.Content = new DateTime(displayYear,displayMonth,1).ToString("MMM yyyy");

            for (int i = 1; i <= iDaysInMonth; i++)
            {
                if ((i != 1) && Math.IEEERemainder((i + iOffsetDays - 1), 7) == 0)
                {

                    Grid.SetRow(weekRowCtrl, iWeekCount);
                    MonthViewGrid.Children.Add(weekRowCtrl);

                    weekRowCtrl = new WeekOfDaysControl();
                    iWeekCount += 1;
                }

  
                DayBoxControl dayBox = new DayBoxControl();
                dayBox.DayNumberLabel.Content = i.ToString();
                dayBox.Tag = i;
                dayBox.MouseDoubleClick += DayBox_DoubleClick;
                dayBox.MouseUp += DayBox_MouseUp;
                dayBox.LostFocus += DayBox_LostFocus;

                if ((new System.DateTime(displayYear, displayMonth, i)) == DateTime.Today)
                {
                    dayBox.DayLabelRowBorder.Background = (Brush)dayBox.TryFindResource("OrangeGradientBrush");
                    dayBox.DayAppointmentsStack.Background = Brushes.Wheat;
                }

                if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                {
                    if (new Random().Next() < 0.25)
                    {
                        AppointmentControl apt = new AppointmentControl();
                        apt.DisplayText.Text = "Apt on " + i + "th";
                        dayBox.DayAppointmentsStack.Children.Add(apt);
                    }

                }
                else if (DataSource != null)
                {
                    int iday = i;
                    List<TourEntityVM> aptInDay = DataSource.Where(apt => apt.Startdate.Day == iday && apt.Startdate.Month == displayMonth).ToList();
                    foreach (TourEntityVM a in aptInDay)
                    {
                        AppointmentControl apt = new AppointmentControl();
                        apt.DisplayText.Text = a.Title;
                        apt.Tag = a.Tour.ID;
                        apt.MouseDoubleClick += Appointment_DoubleClick;
                        apt.MouseUp += Appointment_MouseUp;
                        apt.LostFocus += Appointment_LostFocus;
                        dayBox.DayAppointmentsStack.Children.Add(apt);
                    }

                }

                Grid.SetColumn(dayBox, (i - (iWeekCount * 7)) + iOffsetDays);
                weekRowCtrl.WeekRowGrid.Children.Add(dayBox);
            }
            Grid.SetRow(weekRowCtrl, iWeekCount);
            MonthViewGrid.Children.Add(weekRowCtrl);
        }

        private void DayBox_LostFocus(object sender, RoutedEventArgs e)
        {

            DayBoxControl db = (DayBoxControl)sender;
            if ((new System.DateTime(displayYear, displayMonth, Convert.ToInt32(db.DayNumberLabel.Content)) == DateTime.Today))
            {
                return;
            }
            db.DayLabelRowBorder.Background = (Brush)db.TryFindResource("BlueGradientBrush");
            db.DayAppointmentsStack.Background = Brushes.White;
        }

        private void Appointment_LostFocus(object sender, RoutedEventArgs e)
        {
            AppointmentControl ac = (AppointmentControl)sender;
            ac.BorderElement.Background = Brushes.LightBlue;
            ac.Background = Brushes.White;
        }

        private void Appointment_MouseUp(object sender, RoutedEventArgs e)
        {
            AppointmentControl ac = (AppointmentControl)sender;
            ac.BorderElement.Background = Brushes.Aquamarine;
            ac.Background = Brushes.Azure;
            ac.Focus();
            e.Handled = true;
        }

        private void DayBox_MouseUp(object sender, RoutedEventArgs e)
        {
            DayBoxControl db = (DayBoxControl)sender;
            db.DayLabelRowBorder.Background = Brushes.Aquamarine;
            db.DayAppointmentsStack.Background = Brushes.Azure;
            db.Focus();
        }

        private void AddRowsToMonthGrid(int DaysInMonth, int OffSetDays)
        {
            MonthViewGrid.RowDefinitions.Clear();
            System.Windows.GridLength rowHeight = new System.Windows.GridLength(60, System.Windows.GridUnitType.Star);

            int EndOffSetDays = 7 - (Convert.ToInt32(System.Enum.ToObject(typeof(System.DayOfWeek), displayStartDate.AddDays(DaysInMonth - 1).DayOfWeek)) + 1);

            for (int i = 1; i <= Convert.ToInt32((DaysInMonth + OffSetDays + EndOffSetDays) / 7); i++)
            {
                dynamic rowDef = new RowDefinition();
                rowDef.Height = rowHeight;
                MonthViewGrid.RowDefinitions.Add(rowDef);
            }
        }

        private void UpdateMonth(int MonthsToAdd)
        {
            MonthChangedEventArgs ev = new MonthChangedEventArgs();
            ev.OldDisplayStartDate = displayStartDate;
            this.DisplayStartDate = displayStartDate.AddMonths(MonthsToAdd);
            ev.NewDisplayStartDate = displayStartDate;
            BuildCalendarUI();
        }

        #region "UIEventHandlers "

        private void MonthGoPrev_MouseLeftButtonUp(System.Object sender, MouseButtonEventArgs e)
        {
            UpdateMonth(-1);
        }

        private void MonthGoNext_MouseLeftButtonUp(System.Object sender, MouseButtonEventArgs e)
        {
            UpdateMonth(1);
        }

        private void Appointment_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (object.ReferenceEquals(e.Source.GetType(), typeof(AppointmentControl)))
            {
                if (((AppointmentControl)e.Source).Tag != null)
                {
                    var apt = (AppointmentControl)e.Source;
                    SelectedTour = DataSource.FirstOrDefault((a) => a.Tour.ID == (int)apt.Tag);
                    //if (AppointmentDblClicked != null)
                    //{
                    //    AppointmentDblClicked(Convert.ToInt32(((AppointmentControl)e.Source).Tag));
                    //}
                }
                e.Handled = true;
            }
        }

        private void DayBox_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            //-- call to FindVisualAncestor to make sure they didn't click on existing appointment (in which case,
            //   that appointment window is already opened by handler Appointment_DoubleClick)

            if (object.ReferenceEquals(e.Source.GetType(), typeof(DayBoxControl)) && Utilities.FindVisualAncestor(typeof(AppointmentControl), (Visual)e.OriginalSource) == null)
            {
                NewAppointmentEventArgs ev = new NewAppointmentEventArgs();
                if (((DayBoxControl)e.Source).Tag != null)
                {
                    ev.StartDate = new System.DateTime(displayYear, displayMonth, Convert.ToInt32(((DayBoxControl)e.Source).Tag), 10, 0, 0);
                    ev.EndDate = Convert.ToDateTime(ev.StartDate).AddHours(2);
                }
                if (DayBoxDoubleClicked != null)
                {
                    DayBoxDoubleClicked(ev);
                }
                e.Handled = true;
            }
        }


        #endregion

    }

    public struct MonthChangedEventArgs
    {
        public System.DateTime OldDisplayStartDate;
        public System.DateTime NewDisplayStartDate;
    }

    public struct NewAppointmentEventArgs
    {
        public System.DateTime? StartDate;
        public System.DateTime? EndDate;
        public int? CandidateId;
        public int? RequirementId;
    }

    class Utilities
    {
        //-- Many thanks to Bea Stollnitz, on whose blog I found the original C# version of below in a drag-drop helper class... 
        public static FrameworkElement FindVisualAncestor(System.Type ancestorType, Visual visual)
        {

            while ((visual != null && !ancestorType.IsInstanceOfType(visual)))
            {
                visual = (Visual)VisualTreeHelper.GetParent(visual);
            }
            return (FrameworkElement)visual;
        }
    }
}
