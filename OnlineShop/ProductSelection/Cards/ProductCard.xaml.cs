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

        public void SetProduct(string imagePath, string name, string price)
        {
            // Устанавливаем изображение только если путь не равен null
            if (!string.IsNullOrEmpty(imagePath))
            {
                ProductImage.Source = new BitmapImage(new Uri("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/Cart.png"));
            }
            else
            {
                // Здесь можно установить заглушку или оставить пустым
                ProductImage.Source = null; // Оставляем пустым, если изображения нет
            }

            ProductName.Text = name;
            ProductPrice.Text = price;
        }
    }
}