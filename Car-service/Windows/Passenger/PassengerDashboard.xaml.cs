using Car_service.Components;
using Car_service.Pages.DriversPage;
using Car_service.Pages.PassengerPage;
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

namespace Car_service.Windows.Passenger
{
    /// <summary>
    /// Interaction logic for PassengerDashboard.xaml
    /// </summary>
    public partial class PassengerDashboard : Window
    {
        public static Boolean b = false;
        public static TextBox  whereFrom  = new TextBox();
        public PassengerDashboard()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
        
          SendMessages send =  new SendMessages();
          NamigatorPage.Content  = send;
         
           
            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Bu yerda hozir malumotlar yo'q 3 , 4 kundan keyin qayta ishlatib ko'ring","Information");
        }

        private void btnRating_Click(object sender, RoutedEventArgs e)
        {
            DriverInformation driver = new DriverInformation();
            NamigatorPage.Content = driver;
        }

        private void btnSendMessagesDriver(object sender, RoutedEventArgs e)
        {
            Messages messages = new Messages();
            NamigatorPage.Content = messages;
        }

        private void Booking_Click(object sender, RoutedEventArgs e)
        {
           BookingPassangerPage page  = new BookingPassangerPage();
           NamigatorPage.Content = page;
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }

        private void NamigatorPage_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
