using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OnlineShop.ProductSelection.Cards
{
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
            this.MouseDown += ProductCard_MouseDown; // Добавьте обработчик событий
        }


        private void ProductCard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                // Запуск отображения полной информации
                ((Views.MainWindow)Window.GetWindow(this)).ShowProductDetails(this);
            }
        }

        public void SetProduct(Product product)
        {
            if (!string.IsNullOrEmpty(product.ImagePath))
            {
                ProductImage.Source = new BitmapImage(new Uri(product.ImagePath, UriKind.Relative));
            }
            else
            {
                ProductImage.Source = null;
            }

            ProductName.Text = product.Name;
            ProductPrice.Text = product.Price;
            // Дополнительно можно отобразить категорию, если требуется
        }
    }
}