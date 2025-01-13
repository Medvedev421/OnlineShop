using System.Collections.Generic;
using System.Windows.Controls;
using OnlineShop.ProductSelection.Cards;

namespace OnlineShop.ProductSelection.Cards.Managers
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
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/ShoesImage/Nike.png", "Nike Air Force 1", "14999₽", "Shoes"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/ShoesImage/Botinki3.png", "Ботинки зимние", "5830₽", "Shoes"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/JeansImage/Jeans2.png", "Широкие джинсы", "3488₽", "Jeans"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/JeansImage/JeansClassic.png", "Классические джинсы", "3200₽", "Jeans"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/JacketsImage/Nike.png", "Nike коротка куртка", "9999₽", "Jackets"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/JacketsImage/Jacket.png", "Легкая куртка", "5566₽", "Jackets"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/SweatersImage/Sweater.png", "Кофта оверсайз", "3499₽", "Sweaters"),
            new Cards.Product("pack://application:,,,/OnlineShop;component/ProductSelection/Resource/T-ShirtsImage/Tshirt.png", "Футболка мужская", "1999₽", "T-Shirts"),
        };

        public List<Cards.Product> GetAllAvailableProducts()
        {
            return allAvailableProducts;
        }
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