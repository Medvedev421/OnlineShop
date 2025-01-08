using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Collections.Generic;
using System.Linq;
using MahApps.Metro.Controls;
using OnlineShop.ProductSelection.Cards;

namespace OnlineShop.ProductSelection.Views
{
    public partial class MainWindow : MetroWindow
    {
        private List<Cards.ProductCard> allProducts;
        private Carts.Cart currentCart;


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
                var card = new ProductBuilder()
                    .SetImage("path/to/image.jpg")
                    .SetName($"Товар fff")
                    .SetPrice($"{(i + 1) * 100}₽")
                    .SetCategory("Shoes") // указать категорию, если необходимо
                    .CreateProductCard(); // Используйте CreateProductCard вместо Build

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
                new[]
                {
                    "XS", "S", "M", "L", "XL"
                } // Укажите размеры, которые должны изменяться в зависимости от категории
            );

            ProductPanel.Children.Add(productDetails);
        }

        public Carts.Cart GetCart()
        {
            if (currentCart == null)
            {
                currentCart = new Carts.Cart();
            }

            return currentCart;
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            ProductPanel.Children.Clear(); // Очищаем панель товаров
            var cart = new Carts.Cart();
            ProductPanel.Children.Add(cart);
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
            ProductPanel.Children.Clear(); 
            allProducts.Clear();

            if (sender is Button button)
            {
                string category = button.Tag.ToString(); // Получаем категорию из тега кнопки

                // Вызов методов добавления карточек в зависимости от категории
                switch (category)
                {
                    case "Shoes":
                        AddShoesCard("path/to/shoes/image1.jpg", "Кроссовки", "400₽");
                        AddShoesCard("path/to/shoes/image2.jpg", "Ботинки", "800₽");
                        break;
                    case "Jeans":
                        AddJeansCard("path/to/jeans/image1.jpg", "Джинсы", "1000₽");
                        AddJeansCard("path/to/jeans/image2.jpg", "Классические джинсы", "1200₽");
                        break;
                    case "Jackets":
                        AddJacketsCard("path/to/jackets/image1.jpg", "Куртка", "2500₽");
                        break;
                    case "Sweaters":
                        AddSweatersCard("path/to/sweaters/image1.jpg", "Теплый свитер", "1500₽");
                        break;
                    case "T-Shirts":
                        AddTShirtsCard("path/to/tshirts/image1.jpg", "Футболка", "500₽");
                        break;
                }
            }
        }

        public void AddProductCard(string imagePath, string name, string price, string category)
        {
            var card = new ProductBuilder()
                .SetImage(imagePath)
                .SetName(name)
                .SetPrice(price)
                .SetCategory(category) // Установка категории
                .CreateProductCard(); // Создание карточки

            // Добавляем карточку в интерфейс
            ProductPanel.Children.Add(card);
            allProducts.Add(card); // Храните ссылку на карточку, если нужно
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

        public void AddShoesCard(string imagePath, string name, string price)
        {
            AddProductCard(imagePath, name, price, "Shoes");
        }

        public void AddJeansCard(string imagePath, string name, string price)
        {
            AddProductCard(imagePath, name, price, "Jeans");
        }

        public void AddJacketsCard(string imagePath, string name, string price)
        {
            AddProductCard(imagePath, name, price, "Jackets");
        }

        public void AddSweatersCard(string imagePath, string name, string price)
        {
            AddProductCard(imagePath, name, price, "Sweaters");
        }

        public void AddTShirtsCard(string imagePath, string name, string price)
        {
            AddProductCard(imagePath, name, price, "T-Shirts");
        }
    }
}
