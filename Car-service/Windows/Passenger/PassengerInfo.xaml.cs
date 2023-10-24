using Car_service.Entities.Passengers;
using Car_service.Helper;
using Car_service.Interfaces.Passengers;
using Car_service.Pages.PassengerPage;
using Car_service.Repositiories.Drivers;
using Microsoft.VisualBasic;
using Npgsql.Internal.TypeHandlers.DateTimeHandlers;
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
    /// Interaction logic for PassengerInfo.xaml
    /// </summary>
    public partial class PassengerInfo : Window
    {
        public static TextBox PersonNum  = new TextBox();
        public readonly IPassengerRepository _passenger;
        public static TextBox phonenumber =new TextBox();
        public PassengerInfo()
        {
            InitializeComponent();
            this._passenger = new PassengerRepository();
        }

      

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnsendclick(object sender, RoutedEventArgs e)
        {


            phonenumber.Text = txtPhoneNumber.Text;
            Passager passager = new Passager();

            passager.timeToLeave = soat.Text;
            passager.Name = txtName.Text;
            passager.Phone_number = txtPhoneNumber.Text;
            passager.thereArePassengers = int.Parse(txtThereArePassengres.Text);
            passager.place = SendMessages._Wherefrom.Text;
            passager.place1 = SendMessages._whereto.Text;
            passager.CreatedAt = passager.UpdatedAt = TimeHelper.GetDateTime();
            if (checkBoxMale.IsChecked == true)
            {
                passager.Is_male = true;
            }
            else { passager.Is_male = false; }
            var result = await _passenger.CretaAsync(passager);
            if (result > 0)
            {
                MessageBox.Show("Your information has been sent to the drivers", "Information", MessageBoxButton.OK);


            };
            PersonNum.Text = txtThereArePassengres.Text;
            this.Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
