using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace OnlineShop.ProductSelection.Carts
{
    public partial class Cart : UserControl
    {
        public List<CartItem> CartItems { get; private set; }

        public Cart()
        {
            InitializeComponent();
            CartItems = new List<CartItem>();
        }

        public void AddItem(string productName, string productPrice)
        {
            CartItems.Add(new CartItem { Name = productName, Price = productPrice });
            UpdateCartView();
        }

        private void UpdateCartView()
        {
            ItemsList.Items.Clear();
            foreach (var item in CartItems)
            {
                ItemsList.Items.Add($"{item.Name} - {item.Price}");
            }

            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            decimal total = 0;
            foreach (var item in CartItems)
            {
                total += decimal.Parse(item.Price.TrimEnd('₽'));
            }
            TotalPrice.Text = $"Итого: {total}₽";
        }

        private void ClearCartButton_Click(object sender, RoutedEventArgs e)
        {
            CartItems.Clear();
            UpdateCartView();
        }

        private void CheckoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (CartItems.Count > 0)
            {
                MessageBox.Show("Заказ оформлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearCartButton_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Корзина пуста", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}