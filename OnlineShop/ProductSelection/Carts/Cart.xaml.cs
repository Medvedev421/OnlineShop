using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;

namespace OnlineShop.ProductSelection.Carts
{
    public partial class Cart : UserControl
    {
        public Cart()
        {
            InitializeComponent();
        }

        public void UpdateCartItems(string productName, string imagePath, string productPrice)
        {
            var item = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            // Если изображение указано
            if (!string.IsNullOrEmpty(imagePath))
            {
                var image = new Image 
                { 
                    Source = new BitmapImage(new Uri(imagePath, UriKind.Relative)),
                    Width = 50, 
                    Height = 50, 
                    Margin = new Thickness(0, 0, 10, 0) 
                };
                item.Children.Add(image);
            }
            else
            {
                // Здесь можно добавить заглушку или просто пропустить изображение
                var placeholder = new TextBlock
                {
                    Text = "Изображение отсутствует",
                    Width = 50,
                    Height = 50,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 10, 0)
                };
                item.Children.Add(placeholder);
            }

            // Название товара
            var nameText = new TextBlock
            {
                Text = productName,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 10, 0)
            };

            // Цена товара
            var priceText = new TextBlock
            {
                Text = productPrice,
                VerticalAlignment = VerticalAlignment.Center
            };

            item.Children.Add(nameText);
            item.Children.Add(priceText);

            // Добавляем элемент в список товаров корзины
            ItemsList.Items.Add(item);

            // Вы можете также обновить общую стоимость, если это необходимо
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            // Здесь можно реализовать логику подсчета общей стоимости
            // Пример простого подсчета
            decimal total = 0;
            foreach (var item in ItemsList.Items)
            {
                if (item is StackPanel panel)
                {
                    var priceText = panel.Children[2] as TextBlock;
                    if (priceText != null)
                    {
                        decimal price;
                        if (decimal.TryParse(priceText.Text.Replace("₽", "").Trim(), out price))
                        {
                            total += price;
                        }
                    }
                }
            }
            TotalPrice.Text = $"Итого: {total}₽";
        }

        private void ClearCartButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем список товаров
            ItemsList.Items.Clear();
            TotalPrice.Text = "Итого: 0₽";
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика оформления заказа
            if (ItemsList.Items.Count > 0)
            {
                MessageBox.Show("Заказ оформлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                ItemsList.Items.Clear();
                TotalPrice.Text = "Итого: 0₽";
            }
            else
            {
                MessageBox.Show("Корзина пуста", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        
        public void AddProductToCart(Cards.ProductCard cartItem)
        {
            // Создаем элемент для отображения товара в корзине
            var item = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

            // Создаем изображение, если оно существует
            if (cartItem.ProductImage.Source != null)
            {
                var image = new Image
                {
                    Source = cartItem.ProductImage.Source,
                    Width = 50,
                    Height = 50,
                    Margin = new Thickness(0, 0, 10, 0)
                };
                item.Children.Add(image);
            }

            // Название товара
            var nameText = new TextBlock
            {
                Text = cartItem.ProductName.Text,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 0, 10, 0)
            };

            // Цена товара
            var priceText = new TextBlock
            {
                Text = cartItem.ProductPrice.Text,
                VerticalAlignment = VerticalAlignment.Center
            };

            item.Children.Add(nameText);
            item.Children.Add(priceText);

            // Добавляем элемент в список товаров корзины
            ItemsList.Items.Add(item);
        }
    }
}