using System.Windows;
using System.Windows.Media.Animation;

namespace OnlineShop.ProductSelection
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ShowProductList(); // Отображать список товаров при загрузке
        }
        public void ShowProductList()
        {
            // Очистка панели и добавление карточек
            ProductPanel.Children.Clear();

            // Пример добавления карточек
            for (int i = 0; i < 5; i++)
            {
                ProductCard card = new ProductCard();
                card.SetProduct("path/to/image.jpg", $"Товар {i + 1}", $"{(i + 1) * 100}₽");
                ProductPanel.Children.Add(card);
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
                new[] { "XS", "S", "M", "L", "XL" } // Укажите размеры, которые должны изменяться в зависимости от категории
            );

            ProductPanel.Children.Add(productDetails);
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            ProductPanel.Children.Clear(); // Очищаем панель товаров
            var cart = new Cart();
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
            // Логика обработки нажатия на кнопки категорий
        }
    }
}