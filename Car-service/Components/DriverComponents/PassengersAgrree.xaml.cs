using Car_service.Entities.orderview;
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
    /// Interaction logic for PassengersAgrree.xaml
    /// </summary>
    public partial class PassengersAgrree : UserControl
    {
        private readonly IIBookingPpnDid did;
        public PassengersAgrree()
        {
            InitializeComponent();
            this.did = new BookingPpnDidRepository();
        }
        public void SetData(Orderviews passager)
        {
            txtName.Text = passager.PassengerName;
            txtPhoneNumber.Text = passager.PassengerPhoneNumber;
            txtPlace.Text = passager.wherefrom;
            txtSoat.Text = passager.TimeToLeave;
            txtThereArePassengres.Text = passager.ThereArePassengers.ToString();
            txtplace1.Text = passager.Whereto;
            if (passager.IsMale)
            {
                checkBoxMale.IsChecked = true;
            }
            else
            {
                checkBoxFeMale.IsChecked = true;
            }
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)  
        {

        }

        private async void DeleteClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(DriverLogin.textId.Text);
            var result  = await did.DeletPhoneNumberDriverId(txtPhoneNumber.Text, id);
            if (result != 0)
            {
                MessageBox.Show("This passenger has been removed from your vehicle", "Deleted", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                PassengersAgreeUserControl.Visibility= Visibility.Collapsed;
            }
            else MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
