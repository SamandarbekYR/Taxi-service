using Car_service.Components.DriverComponents;
using Car_service.Components.PassengerComponents;
using Car_service.Interfaces.BookingPpnDid;
using Car_service.Interfaces.orders;
using Car_service.Repositiories.BookingDidPPn;
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
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : Page
    {
        private readonly IIBookingPpnDid did;
        private readonly IOrder order;
        public Messages()
        {
            InitializeComponent();
            this.did = new BookingPpnDidRepository();
            this.order = new OrderRepository(); 
        }


        private async void Page_Loaded_1(object sender, RoutedEventArgs e)
        {
            wrpDriverMessages.Children.Clear();


            if (Passengerlogin.phone.Length > 0)
            {
             var costumer = await order.Search(Passengerlogin.phone.ToString());
                foreach (var cost in costumer)
                {
                    DriverMessagesUserControl userControl = new DriverMessagesUserControl();
                    userControl.SetData(cost);

                    wrpDriverMessages.Children.Add(userControl);
                }
            }
            else if (PassengerInfo.phonenumber.Text.Length>0)
            {
                var costumer = await order.Search(Passengerlogin.phone.ToString());
                foreach (var cost in costumer)
                {
                    DriverMessagesUserControl userControl = new DriverMessagesUserControl();
                    userControl.SetData(cost);

                    wrpDriverMessages.Children.Add(userControl);
                }
            }
       
        }
    }
}
