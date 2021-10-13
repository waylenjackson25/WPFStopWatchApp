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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Diagnostics;

namespace WPFStopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        Stopwatch stopWatch = new Stopwatch();
        string currentTime = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0,0,0,0,1);
        }

        

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (stopWatch.IsRunning) 
            {
                TimeSpan time = stopWatch.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                    time.Minutes, time.Seconds, time.Milliseconds / 10);
                lblTime.Content = currentTime;

            }
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            stopWatch.Start();
            timer.Start();
        }

        private void btn_stop_Click(object sender, RoutedEventArgs e)
        {
            if (stopWatch.IsRunning) 
            {
                stopWatch.Stop();
            }

        }

        private void btn_restart_Click(object sender, RoutedEventArgs e)
        {
            
            stopWatch.Reset();
            lblTime.Content = "00:00:00";
        }

        
    }
}
