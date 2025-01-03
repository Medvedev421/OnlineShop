using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OnlineShop.ProductSelection
{
    public partial class ProductDetails : UserControl
    {
        public ProductDetails()
        {
            InitializeComponent();
        }

        public void SetProduct(string imagePath, string name, string price, string[] sizes)
        {
            ProductImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative)); // Путь к изображению
            ProductName.Text = name;
            ProductPrice.Text = price;

            SizePanel.Children.Clear();
            foreach (var size in sizes)
            {
                TextBlock sizeText = new TextBlock
                {
                    Text = size,
                    Margin = new Thickness(5)
                };
                SizePanel.Children.Add(sizeText);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика возврата — нужно вызвать метод в MainWindow, чтобы вернуться к списку товаров
            ((MainWindow)Window.GetWindow(this)).ShowProductList();
        }
    }
}