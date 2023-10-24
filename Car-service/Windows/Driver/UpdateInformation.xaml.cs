using Car_service.Constants;
using Car_service.Entities.Cars;
using Car_service.Entities.Drivers;
using Car_service.Entities.orderview;
using Car_service.Helper;
using Car_service.Interfaces.Cars;
using Car_service.Interfaces.Drivers;
using Car_service.Repositiories.Cars;
using Car_service.Repositiories.Drivers;
using Car_service.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Car_service.Windows.Driver
{
    /// <summary>
    /// Interaction logic for UpdateInformation.xaml
    /// </summary>
    public partial class UpdateInformation : Window
    {
        public readonly IDriverRepository _driver;
        public readonly ICarRepository _car;
        public UpdateInformation()
        {
            this._car = new CarRepository();
            this._driver = new DriverRopository();
            InitializeComponent();
        }

        private async void SevaButton_Click(object sender, RoutedEventArgs e)
        {
        

                DriverEntitiy driver = new DriverEntitiy();

                // Driver 

                string imagePath = Driverimage.ImageSource.ToString();

                driver.ImagePath = await CopyImage(imagePath, ContentConstants.Image_Path);

                driver.Name = txtDriverName.Text;
                driver.Phone_number = txtDriverPhoneNumber.Text;
                driver.Prava = txtDriverPrava.Text;
                driver.Login = txtDriverLogin.Text;
                driver.City1 = comboCity.Text;
                string password = txtDriverPassword.Text;
                var hasherPassword = PasswordHasher.Hash(password);

                driver.PasswordHash = hasherPassword.PasswordHash;
                driver.Salt = hasherPassword.Salt;



                driver.UpdatedAt = TimeHelper.GetDateTime();

                var result = await _driver.UpdateAsync(long.Parse(DriverLogin.textId.Text), driver);



                string CarImagePath = CarImage.ImageSource.ToString();





                Car car = new Car();
                car.Image_path = await CopyImage(CarImagePath, ContentConstants.Image_Path);
                car.Car_name = txtCarName.Text;
                car.Number = txtCarNumber.Text;
                car.Color = txtCarColor.Text;
                car.Texpasport_seria = txtCarTexpasport.Text;
                car.Description = txtCarDescription.Text;
                car.Description = txtCarDescription.Text;
                car.UpdatedAt = TimeHelper.GetDateTime();

                var result1 = await _car.UpdateAsync(long.Parse(DriverLogin.textId.Text), car);


                this.Close();
           

        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void SetData(DriverEntitiy driver)
        {
            Driverimage.ImageSource = new BitmapImage(new Uri(driver.ImagePath, UriKind.Relative));
            txtDriverName.Text = driver.Name;
            txtDriverLogin.Text = driver.Login;
            txtDriverPhoneNumber.Text = driver.Phone_number;
            txtDriverPrava.Text = driver.Prava;
            comboCity.SelectedItem = driver.City1;
           
        }
        public void SetDataCar(Car car)
        {
            CarImage.ImageSource = new BitmapImage(new Uri(car.Image_path, UriKind.Relative));
            txtCarNumber.Text= car.Number;
            txtCarName.Text= car.Car_name;
            txtCarDescription.Text= car.Description;
            txtCarTexpasport.Text= car.Texpasport_seria;
            txtCarColor.Text= car.Color;
            
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
            int id = int.Parse( DriverLogin.textId.Text);
            var rest = await _driver.GetAsync(id);
            var restCar = await _car.GetAsync(id);
            foreach (var i in rest)
            {
                SetData(i);

            }
            foreach (var j in restCar)
            {
                SetDataCar(j);
            }
        }

        private void btnaCarPictureSelected_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPG Files (*.jpg) |*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFile.ShowDialog()  == System.Windows.Forms.DialogResult.OK)
            {
                string imgPath = openFile.FileName;
                CarImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }

        private void btnDriverPictureSelected_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPG Files (*.jpg) |*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png";
            if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string imgPath = openFile.FileName;
                Driverimage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }
        public async Task<string> CopyImage(string imagePath, string img)
        {

            if (!Directory.Exists(img))
                Directory.CreateDirectory(img);
            var imageName = ContentNameMaker.GetImage(imagePath);

            string path = System.IO.Path.Combine(img, imageName);

            byte[] image = File.ReadAllBytes(imagePath);

            await File.WriteAllBytesAsync(path, image);

            return path;
        }
    }
}
