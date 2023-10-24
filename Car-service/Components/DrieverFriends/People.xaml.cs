using Car_service.Entities.DriverFriends;
using Car_service.Entities.Drivers;
using Car_service.Interfaces.Friends;
using Car_service.Repositiories.Friends;
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

namespace Car_service.Components.DrieverFriends
{
    /// <summary>
    /// Interaction logic for People.xaml
    /// </summary>
    public partial class People : UserControl
    {
        public readonly IFriendsRepository _friends;
        public People()
        {
            InitializeComponent();
            this._friends = new FriednsRepository();
        }

        public long Id { get; private set; }

        public void SetData(driverFriend driver)
        {
            txtDId.Text = driver.DriverId.ToString();
            txtName.Text = driver.Name.ToString();
            txtPhoneNumber.Text = driver.PhoneNumber.ToString();
            if (driver.IsToshkent == false) txtPlace.Text = driver.City.ToString();
            else txtPlace.Text = "Toshkent";
            txtScore.Text = driver.Score.ToString();
            DriverPicture.ImageSource = new BitmapImage(new Uri(driver.ImagePath, UriKind.Relative));

        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(txtDId.Text);

            var result = await _friends.DeleteAsync(id);
            if (result > 0) MessageBox.Show("Removed from favorites");
            else MessageBox.Show("Removal error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            PopleControl.Visibility = Visibility.Collapsed;

        }
    }
}
