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
            new Cards.Product("path/to/shoes/image1.jpg", "Кроссовки", "400₽", "Shoes"),
            new Cards.Product("path/to/shoes/image2.jpg", "Ботинки", "800₽", "Shoes"),
            new Cards.Product("path/to/jeans/image1.jpg", "Джинсы", "1000₽", "Jeans"),
            new Cards.Product("path/to/jeans/image2.jpg", "Классические джинсы", "1200₽", "Jeans"),
            new Cards.Product("path/to/jackets/image1.jpg", "Куртка", "2500₽", "Jackets"),
            new Cards.Product("path/to/jackets/image2.jpg", "Легкая куртка", "2000₽", "Jackets"),
            new Cards.Product("path/to/sweaters/image1.jpg", "Теплый свитер", "1500₽", "Sweaters"),
            new Cards.Product("path/to/tshirts/image1.jpg", "Футболка", "500₽", "T-Shirts"),
            // Добавьте другие товары по мере необходимости
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