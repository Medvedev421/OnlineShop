using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace OnlineShop.ProductSelection.Cards
{
    public partial class ProductCard : UserControl
    {
        public string ImagePath { get; private set; }
        public ProductCard()
        {
            InitializeComponent();
            this.MouseDown += ProductCard_MouseDown; 
        }


        private void ProductCard_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                ((Views.MainWindow)Window.GetWindow(this)).ShowProductDetails(this);
            }
        }

        public void SetProduct(Product product)
        {
            if (!string.IsNullOrEmpty(product.ImagePath))
            { 
                ImagePath = product.ImagePath;
                
                ProductImage.Source = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
            }
            else
            {
                ProductImage.Source = null;
            }

            ProductName.Text = product.Name;
            ProductPrice.Text = product.Price;
        }
    }
}