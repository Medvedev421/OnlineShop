using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Linq;
using MahApps.Metro.Controls;

namespace OnlineShop.ProductSelection.Views
{
    public partial class MainWindow : Window
    {
        private List<Cards.ProductCard> allProducts;

        public MainWindow()
        {
            InitializeComponent();
            allProducts = new List<Cards.ProductCard>();
            ShowProductList(); // Отображать список товаров при загрузке
        }

        public void ShowProductList()
        {
            ProductPanel.Children.Clear();
            allProducts.Clear();

            for (int i = 0; i < 5; i++)
            {
                Cards.ProductCard card = new Cards.ProductCard();
                card.SetProduct("path/to/image.jpg", $"Товар {i + 1}", $"{(i + 1) * 100}₽");
                ProductPanel.Children.Add(card);
                allProducts.Add(card);
            }
        }

        public void ShowProductDetails(Cards.ProductCard card)
        {
            ProductPanel.Children.Clear(); // Очищаем панель товаров

            var productDetails = new Cards.ProductDetails();
            productDetails.SetProduct(
                "path/to/image.jpg", // Укажите путь к изображению
                card.ProductName.Text,
                card.ProductPrice.Text,
                new[] { "XS", "S", "M", "L", "XL" } // Укажите размеры, которые должны изменяться в зависимости от категории
            );

            ProductPanel.Children.Add(productDetails);
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            ProductPanel.Children.Clear(); // Очищаем панель товаров
            var cart = new Carts.Cart();
            ProductPanel.Children.Add(cart);
            // Здесь можно обновить содержимое корзины, если это понадобится
        }

        private void CategoryPanel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Storyboard expandStoryboard = (Storyboard)FindResource("ExpandMenuStoryboard");
            expandStoryboard.Begin();
        }

        private void CategoryPanel_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Storyboard collapseStoryboard = (Storyboard)FindResource("CollapseMenuStoryboard");
            collapseStoryboard.Begin();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                string category = button.Tag.ToString();
                ShowProductListByCategory(category);
            }
        }

        public void ShowProductListByCategory(string category)
        {
            ProductPanel.Children.Clear();
            allProducts.Clear();

            int productCount = 0;
            switch (category)
            {
                case "Shoes":
                    productCount = 3;
                    break;
                case "Jeans":
                    productCount = 5;
                    break;
                case "Jackets":
                    productCount = 4;
                    break;
                case "Sweaters":
                    productCount = 6;
                    break;
                case "T-Shirts":
                    productCount = 2;
                    break;
                default:
                    productCount = 0;
                    break;
            }

            for (int i = 0; i < productCount; i++)
            {
                Cards.ProductCard card = new Cards.ProductCard();
                card.SetProduct("path/to/image.jpg", $"{category} Товар {i + 1}", $"{(i + 1) * 100}₽");
                ProductPanel.Children.Add(card);
                allProducts.Add(card);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            ProductPanel.Children.Clear();

            foreach (var product in allProducts)
            {
                if (product.ProductName.Text.ToLower().Contains(searchText))
                {
                    ProductPanel.Children.Add(product);
                }
            }
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Поиск...")
            {
                SearchBox.Text = string.Empty;
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "Поиск...";
            }
        }
    }
}
