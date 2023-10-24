using Car_service.Components.DrieverFriends;
using Car_service.Components.DriverComponents;
using Car_service.Entities.Passengers;
using Car_service.Interfaces.Passengers;
using Car_service.Repositiories.Drivers;
using Car_service.Unitils;
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

namespace Car_service.Pages
{
    /// <summary>
    /// Interaction logic for MassagesPage.xaml
    /// </summary>
    public partial class MassagesPage : Page
    {
        public readonly  IPassengerRepository _passenger;
        public MassagesPage()
        {
            InitializeComponent();
           this._passenger = new Repositiories.Drivers.PassengerRepository();

        }

      

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var costumer = await _passenger.GetAllTrue();
            foreach (var cost in costumer)
            {
                PassengerInformation information = new PassengerInformation();
                information.SetData(cost);
   
                WRPMessage.Children.Add(information);
            }
        }
    }
}
