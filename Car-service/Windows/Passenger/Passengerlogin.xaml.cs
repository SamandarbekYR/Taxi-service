using Car_service.Constants;
using Car_service.Interfaces.Passengers;
using Car_service.Repositiories.Drivers;
using Npgsql;
using System.Windows;
using System.Windows.Controls;

namespace Car_service.Windows.Passenger
{
    /// <summary>
    /// Interaction logic for Passengerlogin.xaml
    /// </summary>
    public partial class Passengerlogin : Window
    {
     
        public static TextBox TextId= new TextBox();
        public static string phone ;
        public Passengerlogin()
        {
            InitializeComponent();
         
        }

        private void MinimizedButton_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Exit_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Maximized_click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else this.WindowState = WindowState.Maximized;
        }



        private async void btnPassengerLogIn_Click(object sender, RoutedEventArgs e)
        {
            phone = txtPhoneNumber.Text;

            bool IsNumber = int.TryParse(phone, out int a);
            if(IsNumber) {
                await using (var connection = new NpgsqlConnection(DBConstants.DB_CONNECTION_STRING))
                {
                    await connection.OpenAsync();

                    string query = "select *from \"Passenger\"";

                    await using (var command = new NpgsqlCommand(query, connection))
                    {
                        await using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                if (reader.GetString(2) == txtPhoneNumber.Text)
                                {
                                    phone = txtPhoneNumber.Text;

                                    Passengerlogin.TextId.Text = reader.GetInt32(0).ToString();
                                    PassengerDashboard passenger1 = new PassengerDashboard();
                                    this.Hide();
                                    passenger1.ShowDialog();
                                }
                           

                            }
           

                            PassengerDashboard passenger = new PassengerDashboard();
                            this.Hide();
                            passenger.ShowDialog();
                        }

                    }
                    await connection.CloseAsync();
                }
            }
            else MessageBox.Show("Error entering number", "Error",MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
