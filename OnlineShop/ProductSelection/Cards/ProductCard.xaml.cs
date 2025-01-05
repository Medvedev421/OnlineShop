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
            ProductImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            ProductName.Text = name;
            ProductPrice.Text = price;
        }
    }
}