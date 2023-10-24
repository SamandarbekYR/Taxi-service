using Car_service.Components;
using Car_service.Interfaces.DriverCity;
using Car_service.Repositiories.Drivercity;
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
    /// Interaction logic for SendMessages.xaml
    /// </summary>
    public partial class SendMessages : Page
    {
        private readonly ICity city1;
        public static TextBox _whereto = new TextBox();
        public static TextBox _Wherefrom = new TextBox();
        public SendMessages()
        {
            InitializeComponent();
            this.city1 = new CityRepository();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CityCtackPanel.Children.Clear();

            var costumer = await city1.GetAll();
            foreach (var cost in costumer)
            {
                CityUserControl city = new CityUserControl();
                city.SetData(cost);

                CityCtackPanel.Children.Add(city);
            }


        }

     

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            CityToCtackPanel.Children.Clear();

            var costumer = await city1.GetAll();
            foreach (var cost in costumer)
            {
                CityUserControl city = new CityUserControl();
                city.SetData(cost);
                CityToCtackPanel.Children.Add(city);
            }
            _Wherefrom.Text = CityUserControl.box.Text; 
        }

        private void btnToSave_Click(object sender, RoutedEventArgs e)
        {
            _whereto.Text = CityUserControl.box.Text;

            PassengerInfo info = new PassengerInfo();
            info.ShowDialog();


        }
    }
}
