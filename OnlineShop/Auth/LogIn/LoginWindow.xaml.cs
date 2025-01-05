using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using OnlineShop.ProductSelection.Views;
using OnlineShop.Auth.Models;
using OnlineShop.Auth.Registration;

namespace OnlineShop.Auth.LogIn
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            if (ValidateUser(username, password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверные данные. Попробуйте еще раз.");
            }
        }

        private bool ValidateUser(string username, string password)
        {
            var userCollection = LoadUserData();
            return userCollection.Users.Any(u => u.Username == username && u.Password == password);
        }

        private UserCollection LoadUserData()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Auth\\Registration", "UserData.json");
            if (!File.Exists(filePath))
            {
                return new UserCollection();
            }
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<UserCollection>(json) ?? new UserCollection();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Close();
            registerWindow.Show();
        }
    }
}