using Car_service.Entities.Drivers;
using Car_service.Entities.orderview;
using Car_service.Entities.Passengers;
using Car_service.Interfaces.BookingPpnDid;
using Car_service.Interfaces.Drivers;
using Car_service.Interfaces.Passengers;
using Car_service.Repositiories.BookingDidPPn;
using Car_service.Repositiories.Drivers;
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

namespace Car_service.Components.PassengerComponents
{
    /// <summary>
    /// Interaction logic for PassengerBookingUserControl.xaml
    /// </summary>
    public partial class PassengerBookingUserControl : UserControl
    {
        private readonly IIBookingPpnDid did;
        private readonly IDriverRepository driver1;
        private readonly IPassengerRepository passenger;
        public int DriverId; 
        public PassengerBookingUserControl()
        {
            InitializeComponent();
            this.did = new BookingPpnDidRepository();
            this.driver1 = new DriverRopository();
            this.passenger = new PassengerRepository();
        }

        private async void Deleted(object sender, RoutedEventArgs e)
        {

            if(Passengerlogin.phone.Length> 0)
            {

                string Number = Passengerlogin.phone;
                var result = await did.DeletPhoneNumberDriverId(Number, DriverId);
                if (result > 0) MessageBox.Show("Order cancellation", "Order", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                var result3 = await passenger.GetPersonNum(Passengerlogin.phone);
                DriverEntitiy driver = new DriverEntitiy();
                var result2 = await driver1.UpdateBookedMinus(txtPhoneNumber.Text, driver, result3);
            }
            else if(PassengerInfo.phonenumber.Text.Length> 0)
            {
                string Number = PassengerInfo.phonenumber.Text;
                var result = await did.DeletPhoneNumberDriverId(Number, DriverId);
                if (result > 0) MessageBox.Show("Order cancellation", "Order", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                var result3 = await passenger.GetPersonNum(PassengerInfo.phonenumber.Text);
                DriverEntitiy driver = new DriverEntitiy();
                var result2 = await driver1.UpdateBookedMinus(txtPhoneNumber.Text, driver, result3);
            }
         

            MessageBox.Show("Order cancelled","Order",MessageBoxButton.OK,MessageBoxImage.Information);
            PUserControl.Visibility= Visibility.Collapsed;

        }


        internal void SetData(Orderviews cost)
        {
            txtBk.Text = cost.Booked.ToString();
            txtName.Text = cost.Name.ToString();
            txtPhoneNumber.Text = cost.PhoneNumber.ToString();
            txtPlace.Text = cost.Whereto.ToString();
            txtScore.Text = cost.Score.ToString();
            DriverPicture.ImageSource = new BitmapImage(new Uri(cost.ImagePath, UriKind.Relative));
            DriverId = cost.DriverId;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
