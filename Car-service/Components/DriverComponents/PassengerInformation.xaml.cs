using Car_service.Entities.BokkingDidPpn;
using Car_service.Entities.Passengers;
using Car_service.Interfaces.BookingPpnDid;
using Car_service.Repositiories.BookingDidPPn;
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

namespace Car_service.Components.DriverComponents
{
    /// <summary>
    /// Interaction logic for PassengerInformation.xaml
    /// </summary>
    public partial class PassengerInformation : UserControl
    {
        private readonly IIBookingPpnDid _Did;
        public PassengerInformation()
        {
            InitializeComponent();
            this._Did = new BookingPpnDidRepository();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public void SetData(Passager passager)
        {
            txtName.Text = passager.Name;
            txtPhoneNumber.Text = passager.Phone_number;
            txtPlace.Text = passager.place;
            txtSoat.Text = passager.timeToLeave;
            txtThereArePassengres.Text = passager.thereArePassengers.ToString();
            txtplace1.Text = passager.place1;
            if(passager.Is_male)
            {
              checkBoxMale.IsChecked= true;
            }
            else
            {
                checkBoxFeMale.IsChecked= true;
            }
        }

        private async void TakeClick(object sender, RoutedEventArgs e)
        {
            var result1 = await _Did.GetBookingDiagnosis(txtPhoneNumber.Text, int.Parse(DriverLogin.textId.Text));
            if (result1.Count ==0)
            {
                BookingDidPpnEntity booking = new BookingDidPpnEntity();
                booking.DriverId = int.Parse(DriverLogin.textId.Text);
                booking.PassengerPhoneNumber = txtPhoneNumber.Text;
                var result = await _Did.CretaAsync(booking);
                if (result > 0) MessageBox.Show("Your offer has been sent to the passenger","Offer",MessageBoxButton.OK);
            
            }
            else
            {
                MessageBox.Show("You have already sent an offer", "Offer", MessageBoxButton.OK);
            }
        }
    }
}
