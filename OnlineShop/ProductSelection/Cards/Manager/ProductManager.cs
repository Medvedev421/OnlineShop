using System.Collections.Generic;
using System.Windows.Controls;
using OnlineShop.ProductSelection.Cards;

namespace OnlineShop.ProductSelection.Managers
{
    public class ProductManager
    {
        private List<ProductCard> allProducts;
        private Panel productPanel;

        public ProductManager(Panel productPanel)
        {
            this.productPanel = productPanel;
            allProducts = new List<ProductCard>();
        }

        public void ShowProductList()
        {
            productPanel.Children.Clear();
            allProducts.Clear();

            Random random = new Random();
            var selectedProducts = allAvailableProducts.OrderBy(x => random.Next()).Take(5); // Случайным образом берем 5 товаров

            foreach (var product in selectedProducts)
            {
                var card = new ProductBuilder()
                    .SetImage(product.ImagePath)
                    .SetName(product.Name)
                    .SetPrice(product.Price)
                    .SetCategory(product.Category)
                    .CreateProductCard(); // Используйте CreateProductCard вместо Build

                productPanel.Children.Add(card);
                allProducts.Add(card); // Добавляем карточку в список всех продуктов
            }
        }
        
        private List<Cards.Product> allAvailableProducts = new List<Cards.Product>
        {
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/CartImage/Cart.png", "Кроссовки", "400₽", "Shoes"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/CartImage/Cart.png", "Ботинки", "800₽", "Shoes"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/CartImage/Cart.png", "Джинсы", "1000₽", "Jeans"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/CartImage/Cart.png", "Классические джинсы", "1200₽", "Jeans"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/CartImage/Cart.png", "Куртка", "2500₽", "Jackets"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/CartImage/Cart.png", "Легкая куртка", "2000₽", "Jackets"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/CartImage/Cart.png", "Теплый свитер", "1500₽", "Sweaters"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/CartImage/Cart.png", "Футболка", "500₽", "T-Shirts"),
        };

        public void AddProductCard(string imagePath, string name, string price, string category)
        {
            var card = new ProductBuilder()
                .SetImage(imagePath)
                .SetName(name)
                .SetPrice(price)
                .SetCategory(category)
                .CreateProductCard();

            productPanel.Children.Add(card);
            allProducts.Add(card);
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

        public List<ProductCard> GetAllProducts()
        {
            return allProducts;
        }
    }
}