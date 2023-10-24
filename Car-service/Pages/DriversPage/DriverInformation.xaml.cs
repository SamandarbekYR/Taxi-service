using Car_service.Components.DriverComponents;
using Car_service.Interfaces.Drivers;
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

namespace Car_service.Pages.DriversPage
{
    /// <summary>
    /// Interaction logic for DriverInformation.xaml
    /// </summary>
    public partial class DriverInformation : Page
    {
        public readonly IDriverRepository _driver;
        public DriverInformation()
        {
            InitializeComponent();
            this._driver = new DriverRopository();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wrpDriver.Children.Clear();
            PaginationParams pagination = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30
            };
            var costumer = await _driver.GetAllAsync(pagination);
            foreach (var cost in costumer)
            {
                RatingUerControl ratingUerControl=  new RatingUerControl();
                ratingUerControl.SetData(cost);

                wrpDriver.Children.Add(ratingUerControl);
            }
        }
    }
}
