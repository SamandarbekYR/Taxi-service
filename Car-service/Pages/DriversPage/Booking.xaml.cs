using Car_service.Components.DriverComponents;
using Car_service.Entities.BokkingDidPpn;
using Car_service.Entities.Drivers;
using Car_service.Interfaces.BookingPpnDid;
using Car_service.Interfaces.Drivers;
using Car_service.Interfaces.orders;
using Car_service.Repositiories.BookingDidPPn;
using Car_service.Repositiories.Drivers;
using Car_service.Repositiories.orderR;
using Car_service.Unitils;
using Car_service.Windows.Driver;
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

namespace Car_service.Pages.DriversPage
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : Page
    {
        private readonly IOrder order;
        private readonly IIBookingPpnDid did;
        private readonly IDriverRepository driver;
        public Booking()
        {
            InitializeComponent();
            this.order = new OrderRepository();
            this.did = new BookingPpnDidRepository();
            this.driver = new DriverRopository();
            
        }
        private async Task RefreshAsync()
        {
           
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpBooking.Children.Clear();
            PaginationParams pagination = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30
            };
            int id = int.Parse(DriverLogin.textId.Text);
            var costumer = await order.SearchPassengerAgree(id);
            foreach (var cost in costumer)
            {
                PassengersAgrree agrree = new PassengersAgrree();

                agrree.SetData(cost);

                wrpBooking.Children.Add(agrree);
            }
        }

        private async void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(DriverLogin.textId.Text);
            var result = await did.DeleteAsync(id); 
            DriverEntitiy driver1 = new DriverEntitiy();
            var res = await driver.UpdateBookedZero(id, driver1);
            MessageBox.Show("Mission completed", "The end", MessageBoxButton.OK, MessageBoxImage.Information);
            wrpBooking.Children.Clear();
        }
    }
}
