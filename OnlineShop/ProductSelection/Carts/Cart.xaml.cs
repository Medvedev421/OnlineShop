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


        private void ClearCartButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем список товаров
            ItemsList.Items.Clear();
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Логика оформления заказа
            if (ItemsList.Items.Count > 0)
            {
                MessageBox.Show("Заказ оформлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                ItemsList.Items.Clear();
            }
            else
            {
                MessageBox.Show("Корзина пуста", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}