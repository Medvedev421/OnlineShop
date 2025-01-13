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
                        productManager.AddShoesCard("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/ShoesImage/Nike.png", "Nike Air Force 1", "14999₽");
                        productManager.AddShoesCard("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/ShoesImage/Botinki3.png", "Ботинки зимние", "5830₽");
                        break;
                    case "Jeans":
                        productManager.AddJeansCard("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/JeansImage/Jeans2.png", "Широкие джинсы", "3488₽");
                        productManager.AddJeansCard("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/JeansImage/JeansClassic.png", "Классические джинсы", "3200₽");
                        break;
                    case "Jackets":
                        productManager.AddJacketsCard("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/JacketsImage/Nike.png", "Nike короткая куртка", "9999₽");
                        productManager.AddJacketsCard("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/JacketsImage/Jacket.png", "Легкая куртка", "5566₽");
                        break;
                    case "Sweaters":
                        productManager.AddSweatersCard("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/SweatersImage/Sweater.png", "Кофта оверсайз", "3499₽");
                        break;
                    case "T-Shirts":
                        productManager.AddTShirtsCard("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/T-ShirtsImage/Tshirt.png", "Футболка мужская", "1999₽");
                        break;
                }
            }
        }

        public void ShowProductDetails(ProductCard card)
        {
            ProductPanel.Children.Clear(); // Очищаем панель товаров

            var productDetails = new ProductDetails();
            productDetails.SetProduct(
                card.ImagePath, // Укажите путь к изображению
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