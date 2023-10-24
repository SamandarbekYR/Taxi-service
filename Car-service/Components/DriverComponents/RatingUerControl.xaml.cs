using Car_service.Entities.DriverFriends;
using Car_service.Entities.Drivers;
using Car_service.Interfaces.Friends;
using Car_service.Repositiories.Friends;
using Car_service.Unitils;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    /// Interaction logic for RatingUerControl.xaml
    /// </summary>
    public partial class RatingUerControl : UserControl
    {
        public readonly IFriendsRepository _friends;
        public RatingUerControl()
        {
            InitializeComponent();
            this._friends = new FriednsRepository();
        }

        private async void SendClick(object sender, RoutedEventArgs e)
        {
            List<driverFriend> friends =  await _friends.CheckId(int.Parse(txtDId.Text));
        
            if(friends.Count == 0)
            {

            PaginationParams pagination = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30
            };
 
            driverFriend driver = new driverFriend();
            driver.Name = txtName.Text;
            driver.PhoneNumber = txtPhoneNumber.Text;
            driver.City = txtPlace.Text;
            driver.ImagePath = DriverPicture.ImageSource.ToString();
            driver.DriverId = int.Parse(txtDId.Text);
            var result = await _friends.CretaAsync(driver);

            MessageBox.Show("Added to favorites");
           

            }
            else
            {
                MessageBox.Show("This person is in the list of favorites", "Information", MessageBoxButton.OK);
            }
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void SetData(DriverEntitiy driver)
        {
            txtDId.Text = driver.Id.ToString();
            txtName.Text = driver.Name.ToString();
            txtPhoneNumber.Text = driver.Phone_number.ToString();
            txtPlace.Text = driver.City1.ToString();
            txtScore.Text = driver.Rating.ToString();
            DriverPicture.ImageSource = new BitmapImage(new Uri(driver.ImagePath, UriKind.Relative));

        }
    }
}
