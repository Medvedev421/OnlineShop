using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace OnlineShop.ProductSelection.Cards
{
public partial class ProductDetails : UserControl
{
private string selectedSize = null; // Для хранения выбранного размера


    public ProductDetails()
    {
        InitializeComponent();
    }

    public void SetProduct(string imagePath, string name, string price, string[] sizes)
    {
        ProductImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
        ProductName.Text = name;
        ProductPrice.Text = price;

        SizePanel.Children.Clear();
        foreach (var size in sizes)
        {
            Button sizeButton = new Button
            {
                Content = size,
                Margin = new Thickness(5),
                Tag = size // Хранит значение размера
            };

            sizeButton.Click += SizeButton_Click; // Добавляем обработчик клика
            SizePanel.Children.Add(sizeButton);
        }
    }

    private void SizeButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button sizeButton)
        {
            // Отменяем выделение других кнопок
            foreach (var child in SizePanel.Children)
            {
                if (child is Button btn)
                {
                    btn.Background = Brushes.Transparent; // Сброс цвета фона
                }
            }

            // Устанавливаем выделение для текущей кнопки
            sizeButton.Background = Brushes.LightBlue;
            selectedSize = sizeButton.Tag.ToString(); // Запоминаем выбранный размер

            // Активируем кнопку "В корзину"
            AddToCartButton.IsEnabled = true;
        }
    }

    private void BackButton_Click(object sender, RoutedEventArgs e)
    {
        // Логика возврата — нужно вызвать метод в MainWindow, чтобы вернуться к списку товаров
        ((Views.MainWindow)Window.GetWindow(this)).ShowProductList();
    }

    private void AddToCartButton_Click(object sender, RoutedEventArgs e)
    {
        if (selectedSize != null)
        {
            MessageBox.Show($"{ProductName.Text} (Размер: {selectedSize}) добавлен в корзину!");
        }
        else
        {
            MessageBox.Show("Пожалуйста, выберите размер!");
        }
    }
}
}