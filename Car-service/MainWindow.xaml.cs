using Car_service.Windows.Driver;
using Car_service.Windows.Passenger;
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

namespace Car_service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Maximized_click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
                this.WindowState = WindowState.Maximized;

        }

        private void MinimizedButton_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;  
        }

      

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnPassenger_Click(object sender, RoutedEventArgs e)
        {
            Passengerlogin passengerlogin  = new Passengerlogin();
            this.Hide();
            passengerlogin.ShowDialog();
        }
       
        private void btnDriver_Click(object sender, RoutedEventArgs e)
        {
            DriverLogin driver = new DriverLogin();
            this.Hide();
            driver.ShowDialog();

         
        }

    }
}
