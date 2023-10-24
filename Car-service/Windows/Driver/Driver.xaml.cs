using Car_service.Pages;
using Car_service.Pages.DriversPage;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Car_service.Windows.Driver
{
    /// <summary>
    /// Interaction logic for Driver.xaml
    /// </summary>
    public partial class Driver : System.Windows.Window
    {
        public Driver()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount ==2)
            {
                if(IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized= false;
                }
                else
                {
                    this.WindowState= WindowState.Maximized;
                    IsMaximized= true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void PageNavigator_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }

        private void btnButtonHome_Click(object sender, RoutedEventArgs e)
        {
              Home home = new Home();
              NamigatorPage.Content = home;
              MessageBox.Show("Samabdarbek");
        }

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            Home home = new Home();
            NamigatorPage.Content = home;
            MessageBox.Show("Noqulayliklar uchun uzur so'raymiz! Bu oynada tamirlash ishlari olib borilmoqda.... ", "Information", MessageBoxButton.OK);
        }

        private void btnRating_Click(object sender, RoutedEventArgs e)
        {
            DriverInformation page = new DriverInformation();
            NamigatorPage.Content = page;
        }


        private void FriendButton1_Click(object sender, RoutedEventArgs e)
        {
            FriendsGroup group = new FriendsGroup();
            NamigatorPage.Content = group;
           
        }

        private void btnMessages_Click(object sender, RoutedEventArgs e)
        {
            MassagesPage page = new MassagesPage();
            NamigatorPage.Content = page;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow main = new MainWindow();
            main.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

   

        private void Setting_Click(object sender, RoutedEventArgs e)
        {
           UpdateInformation information = new UpdateInformation();
           information.ShowDialog();
            
        }

        private void BookingClick(object sender, RoutedEventArgs e)
        {
            Booking booking = new Booking();
            NamigatorPage.Content = booking;

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Here you can see the news in the program. There are no news yet", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void NamigatorPage_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
