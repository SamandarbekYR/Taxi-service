using Car_service.Constants;
using Npgsql;
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
using System.Windows.Shapes;

namespace Car_service.Windows.Driver
{
    /// <summary>
    /// Interaction logic for DriverLogin.xaml
    /// </summary>
    public partial class DriverLogin : Window
    {
        public static TextBox textId = new TextBox();
       
        public DriverLogin()
        {
            InitializeComponent();
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
            else
                this.WindowState = WindowState.Maximized;
        }

        private void MinimizedButton_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void DriverLoad_Loaded(object sender, RoutedEventArgs e)
        {

            if (Register.check.IsChecked == true) this.ShowDialog(); 
        }

        private async void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            string password = txbPassword.Password;
            await using (var connection = new NpgsqlConnection(DBConstants.DB_CONNECTION_STRING))
            {
                await connection.OpenAsync();

                string query = "select *from \"Driver\"";

                await using (var command = new NpgsqlCommand(query, connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            if (reader.GetString(3) == txbLogIn.Text)
                            {
                                string password_hash = reader.GetString(12);
                                string salt = reader.GetString(13);
                                bool a = BCrypt.Net.BCrypt.Verify(password + salt, password_hash);
                                if (a)
                                {
                                    textId.Text = reader.GetInt32(0).ToString();

                                    Driver driver = new Driver();
                                    this.Hide();
                                    driver.ShowDialog();
                                }
                            }
                               
                        }
                    }
                }

                await connection.CloseAsync();
            }
        }
    }
}
