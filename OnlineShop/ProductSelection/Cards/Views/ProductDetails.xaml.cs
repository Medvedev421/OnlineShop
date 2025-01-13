using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace OnlineShop.ProductSelection.Cards
{
    public partial class ProductDetails : UserControl
    {
        private string selectedSize = null; 


        public ProductDetails()
        {
            InitializeComponent();
        }

        public void SetProduct(string imagePath, string name, string price, string[] sizes)
        {
            if (!string.IsNullOrWhiteSpace(imagePath)) 
            {
                try
                {
                    ProductImage.Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}");
                    ProductImage.Source = null; 
                }
            }
            else
            {
                MessageBox.Show("Путь к изображению не может быть пустым.");
                ProductImage.Source = null; 
            }

            ProductName.Text = name;
            ProductPrice.Text = price;

            SizePanel.Children.Clear();
            foreach (var size in sizes)
            {
                Button sizeButton = new Button
                {
                    Content = size,
                    Margin = new Thickness(5),
                    Tag = size 
                };

                sizeButton.Click += SizeButton_Click;
                SizePanel.Children.Add(sizeButton);
            }
        }

        private void SizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button sizeButton)
            {
                foreach (var child in SizePanel.Children)
                {
                    if (child is Button btn)
                    {
                        btn.Background = Brushes.Transparent; 
                    }
                }
                
                sizeButton.Background = Brushes.LightBlue;
                selectedSize = sizeButton.Tag.ToString(); 
                
                AddToCartButton.IsEnabled = true;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (Views.MainWindow)Window.GetWindow(this);
            mainWindow.ProductManager.ShowProductList(); 
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedSize != null)
            {
                var mainWindow = (Views.MainWindow)Window.GetWindow(this);
                var currentCart = mainWindow.GetCart();
                
                currentCart.AddItem(ProductName.Text, ProductPrice.Text);
        
                MessageBox.Show($"{ProductName.Text} (Размер: {selectedSize}) добавлен в корзину!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите размер!");
            }
        }
    }
}
