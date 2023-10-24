using Car_service.Constants;
using Car_service.Interfaces.DriverCity;
using Car_service.Repositiories.Drivercity;
using MaterialDesignColors.Recommended;
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

namespace Car_service.Components
{
    /// <summary>
    /// Interaction logic for CityUserControl.xaml
    /// </summary>
    public partial class CityUserControl : UserControl
    {
        public static TextBox box = new TextBox();
        public CityUserControl()
        {
            InitializeComponent();
           
        }
        public void SetData(City city)
        {
            lbname.Content = city.cities;   
        }
        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            lbname.Background= new SolidColorBrush(Colors.Gray);
            
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            lbname.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
  
            box.Text = lbname.Content.ToString();
            lbname.Background = new SolidColorBrush(Colors.DarkCyan);
        }
    }
}
