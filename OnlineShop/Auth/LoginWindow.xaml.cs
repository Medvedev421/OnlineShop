using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace OnlineShop.Auth
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
            if (!File.Exists("UserData.json"))
            {
                return new UserCollection();
            }
            var json = File.ReadAllText("UserData.json");
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