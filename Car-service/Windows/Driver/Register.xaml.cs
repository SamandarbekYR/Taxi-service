using Car_service.Components;
using Car_service.Constants;
using Car_service.Entities.Cars;
using Car_service.Entities.Drivers;
using Car_service.Helper;
using Car_service.Interfaces.Cars;
using Car_service.Interfaces.DriverCity;
using Car_service.Interfaces.Drivers;
using Car_service.Repositiories.Cars;
using Car_service.Repositiories.Drivercity;
using Car_service.Repositiories.Drivers;
using Car_service.Security;
using Microsoft.Win32;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;

namespace Car_service.Windows.Driver
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private readonly IDriverRepository _driverRepositiry;
        private readonly ICarRepository _carRepository;
        public static TextBox textt = new TextBox();
        public static CheckBox check = new CheckBox();
        private readonly ICity citty;
        public static Register Instance { get; set; }
        public Register()
        {
            InitializeComponent();
            this._driverRepositiry = new DriverRopository();
            this._carRepository = new CarRepository();
            this.citty = new CityRepository();

        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        public async Task<string> CopyImage(string imagePath, string img)
        {

            if (!Directory.Exists(img))
                Directory.CreateDirectory(img);
            var imageName = ContentNameMaker.GetImage(imagePath);

            string path = Path.Combine(img, imageName);

            byte[] image = File.ReadAllBytes(imagePath);

            await File.WriteAllBytesAsync(path, image);

            return path;
        }

        private void btnaCarPictureSelected_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPG Files (*.jpg) |*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFile.ShowDialog() == true)
            {
                string imgPath = openFile.FileName;
                CarImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }

        }

        private void btnDriverPictureSelected_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPG Files (*.jpg) |*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFile.ShowDialog() == true)
            {
                string imgPath = openFile.FileName;
                Driverimage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }

        private async void SevaButton_Click(object sender, RoutedEventArgs e)
        {
            DriverEntitiy driver = new DriverEntitiy();

            int j = 0;
            // Driver 

            string imagePath = Driverimage.ImageSource.ToString();

            if (!String.IsNullOrEmpty(imagePath))
            {
                driver.ImagePath = await CopyImage(imagePath, ContentConstants.Image_Path);
                j++;
            }
            else
            {
                DriverPhote.Text += "*";
                DriverPhote.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (!String.IsNullOrEmpty(txtDriverName.Text))
            {
                driver.Name = txtDriverName.Text;
                j++;
            }
            else
            {
                Fn.Text += "*";
                Fn.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (!String.IsNullOrEmpty(txtDriverPhoneNumber.Text))
            {
                driver.Phone_number = txtDriverPhoneNumber.Text;
                j++;

            }
            else
            {
                PN.Text += "*";
                PN.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (!String.IsNullOrEmpty(txtDriverPrava.Text))
            {
                driver.Prava = txtDriverPrava.Text;
                j++;
            }
            else
            {
                Dl.Text += "*";
                Dl.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (!String.IsNullOrEmpty(txtDriverLogin.Text))
            {
                driver.Login = txtDriverLogin.Text;
                j++;
            }
            else
            {
                loginl.Text += "*";
                loginl.Foreground = new SolidColorBrush(Colors.Red);
            }


            if (CityUserControl.box.Text != null)
            {
                driver.City1 = CityUserControl.box.Text.ToString();

            }
            else
            {
                CityT.Text += "*";
                CityT.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (!String.IsNullOrEmpty(PasswordL.Text))
            {
                string password = txtDriverPassword.Text;

                var hasherPassword = PasswordHasher.Hash(password);

                driver.PasswordHash = hasherPassword.PasswordHash;
                driver.Salt = hasherPassword.Salt;
                j++;
            }
            else
            {
                PasswordL.Text += "*";
                PasswordL.Foreground = new SolidColorBrush(Colors.Red);
            }


            driver.CreatedAt = driver.UpdatedAt = TimeHelper.GetDateTime();

            var result = await _driverRepositiry.CretaAsync(driver);

            if (!String.IsNullOrEmpty(txtDriverLogin.Text))
            {
                driver.Login = txtDriverLogin.Text;
                j++;
            }
            else
            {
                loginl.Text += "*";
                loginl.Foreground = new SolidColorBrush(Colors.Red);
            }



            Car car = new Car();

            string CarImagePath = CarImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(CarImagePath))
            {
                car.Image_path = await CopyImage(CarImagePath, ContentConstants.Image_Path);
                j++;
            }
            else
            {
                carimagel.Text += "*";
                carimagel.Foreground = new SolidColorBrush(Colors.Red);
            }



            if (!String.IsNullOrEmpty(txtCarName.Text))
            {
                car.Car_name = txtCarName.Text;
                j++;
            }
            else
            {
                CarNamel.Text += "*";
                CarNamel.Foreground = new SolidColorBrush(Colors.Red);
            }



            if (!String.IsNullOrEmpty(txtCarNumber.Text))
            {
                car.Number = txtCarNumber.Text;
                j++;
            }
            else
            {
                carnumberL.Text += "*";
                carnumberL.Foreground = new SolidColorBrush(Colors.Red);
            }
            car.Color = txtCarColor.Text;


            if (!String.IsNullOrEmpty(txtCarTexpasport.Text))
            {
                car.Texpasport_seria = txtCarTexpasport.Text;
                j++;
            }
            else
            {
                this.txpsL.Text += "*";
                this.txpsL.Foreground = new SolidColorBrush(Colors.Red);
            }



            car.Description = txtCarDescription.Text;
            car.CreatedAt = car.UpdatedAt = TimeHelper.GetDateTime();

            var result1 = await _carRepository.CretaAsync(car);
            check.IsChecked = true;

            if (j == 11) this.Close();



        }



        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            check.IsChecked = false;

            CityCtackPanel.Children.Clear();

            var costumer = await citty.GetAll();
            foreach (var cost in costumer)
            {
                CityUserControl city = new CityUserControl();
                city.SetData(cost);

                CityCtackPanel.Children.Add(city);
            }



        }

        private void mouse(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
