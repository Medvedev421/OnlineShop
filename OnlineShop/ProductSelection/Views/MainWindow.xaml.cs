using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using MahApps.Metro.Controls;
using OnlineShop.ProductSelection.Cards;
using OnlineShop.ProductSelection.Managers;

namespace OnlineShop.ProductSelection.Views
{
    public partial class MainWindow : MetroWindow
    {
        private ProductManager productManager; // Объект для управления продуктами
        private Carts.Cart currentCart;

        public MainWindow()
        {
            InitializeComponent();
            productManager = new ProductManager(ProductPanel); // Передаем панель для отображения товаров
            productManager.ShowProductList(); // Отображать список товаров при загрузке
        }
        public ProductManager ProductManager
        {
            get { return productManager; }
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
            ProductPanel.Children.Clear();
            var cart = GetCart(); // Получаем текущую корзину
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

            if (sender is Button button)
            {
                string category = button.Tag.ToString(); // Получаем категорию из тега кнопки

                // Вызов методов добавления карточек в зависимости от категории
                switch (category)
                {
                    case "Shoes":
                        productManager.AddShoesCard("path/to/shoes/image1.jpg", "Кроссовки", "400₽");
                        productManager.AddShoesCard("path/to/shoes/image2.jpg", "Ботинки", "800₽");
                        break;
                    case "Jeans":
                        productManager.AddJeansCard("path/to/jeans/image1.jpg", "Джинсы", "1000₽");
                        productManager.AddJeansCard("path/to/jeans/image2.jpg", "Классические джинсы", "1200₽");
                        break;
                    case "Jackets":
                        productManager.AddJacketsCard("path/to/jackets/image1.jpg", "Куртка", "2500₽");
                        break;
                    case "Sweaters":
                        productManager.AddSweatersCard("path/to/sweaters/image1.jpg", "Теплый свитер", "1500₽");
                        break;
                    case "T-Shirts":
                        productManager.AddTShirtsCard("path/to/tshirts/image1.jpg", "Футболка", "500₽");
                        break;
                }
            }
        }

        public void ShowProductDetails(ProductCard card)
        {
            ProductPanel.Children.Clear(); // Очищаем панель товаров

            var productDetails = new ProductDetails();
            productDetails.SetProduct(
                "path/to/image.jpg", // Укажите путь к изображению
                card.ProductName.Text,
                card.ProductPrice.Text,
                new[] { "XS", "S", "M", "L", "XL" } // Укажите размеры
            );

            ProductPanel.Children.Add(productDetails);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            ProductPanel.Children.Clear();

            foreach (var product in productManager.GetAllProducts())
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