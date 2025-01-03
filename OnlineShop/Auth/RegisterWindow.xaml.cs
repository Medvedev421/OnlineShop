using System.IO;
using System.Windows;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OnlineShop.Auth
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e) 
        {
            string username = RegisterUsernameTextBox.Text;
            string password = RegisterPasswordTextBox.Password;
            string confirmPassword = ConfirmPasswordTextBox.Password;
            MessageTextBlock.Text = "";

            if (UsernameExists(username))
            {
                MessageTextBlock.Text = "Логин уже существует.";
                return;
            }

            if (password != confirmPassword)
            {
                MessageTextBlock.Text = "Пароли не совпадают.";
                return;
            }

            if (!HasUpperCase(password))
            {
                MessageTextBlock.Text = "Пароль должен содержать хотя бы одну заглавную букву.";
                return;
            }

            if (!HasDigit(password))
            {
                MessageTextBlock.Text = "Пароль должен содержать хотя бы одну цифру.";
                return;
            }

            SaveUserData(username, password);
            MessageBox.Show("Успешная регистрация!");
            GoBackToLogin();
        }

        private bool UsernameExists(string username)
        {
            var userCollection = LoadUserData();
            return userCollection.Users.Any(u => u.Username == username);
        }

        private bool HasUpperCase(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool HasDigit(string password)
        {
            return password.Any(char.IsDigit);
        }

        private void SaveUserData(string username, string password)
        {
            var userCollection = LoadUserData();
            userCollection.Users.Add(new User { Username = username, Password = password });
            File.WriteAllText("UserData.json", JsonConvert.SerializeObject(userCollection));
        }

        private UserCollection LoadUserData()
        {
            if (!File.Exists("UserData.json"))
            {
                return new UserCollection();
            }
            var json = File.ReadAllText("UserData.json");
            return JsonConvert.DeserializeObject<UserCollection>(json) ?? new UserCollection();
        }

        private void GoBackToLogin()
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}