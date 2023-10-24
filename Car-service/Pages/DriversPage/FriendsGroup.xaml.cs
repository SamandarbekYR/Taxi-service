using Car_service.Components.DrieverFriends;
using Car_service.Entities.DriverFriends;
using Car_service.Interfaces.Friends;
using Car_service.Repositiories.Friends;
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
    /// Interaction logic for FriendsGroup.xaml
    /// </summary>
    public partial class FriendsGroup : Page
    {
        private readonly IFriendsRepository _friendsRepository;
        public FriendsGroup()
        {
            InitializeComponent();
            this._friendsRepository = new FriednsRepository();

                }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            wprFriend.Children.Clear();
            PaginationParams pagination = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30
            };
            var friend = await _friendsRepository.GetAllAsync(pagination);
            foreach(var driver in friend)
            {
                People people = new People();
                people.SetData(driver);
                wprFriend.Children.Add(people);
            }


        }
    }
}
