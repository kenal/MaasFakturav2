using Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Desktop
{
    /// <summary>
    /// Interaction logic for KalendarWindow.xaml
    /// </summary>
    public partial class KalendarRadnikWindow : Window
    {
        KalendarRadnikWindowViewModel viewModel = new KalendarRadnikWindowViewModel();

        public KalendarRadnikWindowViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }
        public KalendarRadnikWindow()
        {
            InitializeComponent();
            this.DataContext = ViewModel;
            scheduleControl.Mode = WpfScheduler.Mode.Month;
        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.PrevPage();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.NextPage();
        }

        private void btnModeMonth_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.Mode = WpfScheduler.Mode.Month;
        }

        private void btnModeWeek_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.Mode = WpfScheduler.Mode.Week;
        }

        private void btnModeDay_Click(object sender, RoutedEventArgs e)
        {
            scheduleControl.Mode = WpfScheduler.Mode.Day;
        }

        private void WeekScheduler_OnEventDoubleClick(object sender, WpfScheduler.Event e)
        {
            KalendarRadnikWindowViewModel vm = grid.DataContext as KalendarRadnikWindowViewModel;
            vm.EditEventCommand.Execute(e);
        }

        private void WeekScheduler_OnScheduleDoubleClick(object sender, DateTime date)
        {
            KalendarRadnikWindowViewModel vm = grid.DataContext as KalendarRadnikWindowViewModel;
            vm.NewEventCommand.Execute(date);
            
        }
    }
}
