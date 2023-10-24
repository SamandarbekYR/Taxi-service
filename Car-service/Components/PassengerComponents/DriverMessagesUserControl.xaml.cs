using Car_service.Entities.BokkingDidPpn;
using Car_service.Entities.DriverFriends;
using Car_service.Entities.Drivers;
using Car_service.Entities.orderview;
using Car_service.Entities.Passengers;
using Car_service.Interfaces.BookingPpnDid;
using Car_service.Interfaces.Drivers;
using Car_service.Interfaces.Passengers;
using Car_service.Repositiories.BookingDidPPn;
using Car_service.Repositiories.Drivers;
using Car_service.Windows.Passenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Car_service.Components.PassengerComponents
{
    /// <summary>
    /// Interaction logic for DriverMessagesUserControl.xaml
    /// </summary>
    public partial class DriverMessagesUserControl : UserControl
    {
        private readonly IIBookingPpnDid did;
        private readonly IPassengerRepository passenger;
        private readonly IDriverRepository _driver;
        public DriverMessagesUserControl()
        {
            InitializeComponent();
            this.did = new BookingPpnDidRepository();
            this.passenger = new PassengerRepository();
            this._driver = new DriverRopository();
        }

        private async void gubutton(object sender, RoutedEventArgs e)
        {
            bool a = false;
            if(Passengerlogin.phone.Length>0)
            {

            var res = await did.GetIsAgree(Passengerlogin.phone);
            a =res;
            }
            else
            {
                var res = await did.GetIsAgree(PassengerInfo.phonenumber.Text);
                a =res;
            }
            if (a==false)
            {
                Passager passager = new Passager();
                passager.IsAktiv = false;
                if (Passengerlogin.phone.Length > 0)
                {
                    var result1 = await passenger.UpdateAktiv(Passengerlogin.phone, passager);
                    var result3 = await passenger.GetPersonNum(Passengerlogin.phone);
                    DriverEntitiy driver = new DriverEntitiy();
                    var result2 = await _driver.UpdateBooked(txtPhoneNumber.Text, driver, result3);

                }
                else if (PassengerInfo.phonenumber.Text.Length > 0)
                {
                    var result1 = await passenger.UpdateAktiv(PassengerInfo.phonenumber.Text, passager);
                    var result3 = await passenger.GetPersonNum(PassengerInfo.phonenumber.Text);
                    DriverEntitiy driver = new DriverEntitiy();
                    var result2 = await _driver.UpdateBooked(txtPhoneNumber.Text, driver, result3);
                }

                BookingDidPpnEntity entity = new BookingDidPpnEntity();
                entity.IsAgree = true;

                if (Passengerlogin.phone.Length > 0)
                {
                    var result = await did.UpdateIsAgree(Passengerlogin.phone, entity);
                    if (result > 0) MessageBox.Show("Congratulations, you have reserved your place", "successful", MessageBoxButton.OK);
                }
                else if (PassengerInfo.phonenumber.Text.Length > 0)
                {
                    var result = await did.UpdateIsAgree(PassengerInfo.phonenumber.Text, entity);
                    if (result > 0) MessageBox.Show("Congratulations, you have reserved your place", "successful", MessageBoxButton.OK);
                }
            }
           
           
            

        }
        public void SetData(Orderviews orderviews)
        {
            txtScore.Text = orderviews.Score.ToString();
            txtDId.Text = orderviews.DriverId.ToString();
            txtName.Text = orderviews.Name.ToString();
            txtPhoneNumber.Text = orderviews.PhoneNumber.ToString();
            if (orderviews.IsToshket == false) txtPlace.Text = orderviews.place1.ToString();
            else txtPlace.Text = "Toshkent";
            DriverPicture.ImageSource = new BitmapImage(new Uri(orderviews.ImagePath, UriKind.Relative));

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
