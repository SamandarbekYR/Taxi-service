using Car_service.Components.DriverComponents;
using Car_service.Components.PassengerComponents;
using Car_service.Interfaces.orders;
using Car_service.Repositiories.orderR;
using Car_service.Unitils;
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

namespace Car_service.Pages.PassengerPage
{
    /// <summary>
    /// Interaction logic for BookingPassangerPage.xaml
    /// </summary>
    public partial class BookingPassangerPage : Page
    {
        private readonly IOrder order; 
        public BookingPassangerPage()
        {
            InitializeComponent();
            this.order = new OrderRepository();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpBookingPassenger.Children.Clear();
            PaginationParams pagination = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30
            };
            if (Passengerlogin.phone.Length > 0)
            {
                string PhoneNumber = Passengerlogin.phone;
                var costumer = await order.SearchDriverInfo(PhoneNumber);
                foreach (var cost in costumer)
                {
                    PassengerBookingUserControl userControl = new PassengerBookingUserControl();
                    userControl.SetData(cost);
                    wrpBookingPassenger.Children.Add(userControl);
                }
            }
            else if (PassengerInfo.phonenumber.Text.Length > 0)
            {
                string PhoneNumber = PassengerInfo.phonenumber.Text;

            var costumer = await order.SearchDriverInfo(PhoneNumber);
            foreach (var cost in costumer)
            {
                PassengerBookingUserControl userControl = new PassengerBookingUserControl();
                userControl.SetData(cost);
                wrpBookingPassenger.Children.Add(userControl);
            }
            }
        }
    }
}
