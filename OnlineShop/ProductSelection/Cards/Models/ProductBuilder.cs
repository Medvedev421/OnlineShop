using OnlineShop.ProductSelection.Cards;

namespace OnlineShop.ProductSelection.Cards
{
    public class ProductBuilder
    {
        private string _imagePath;
        private string _name;
        private string _price;
        private string _category;


        public ProductBuilder SetImage(string imagePath)
        {
            _imagePath = imagePath;
            return this;
        }

        public ProductBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public ProductBuilder SetPrice(string price)
        {
            _price = price;
            return this;
        }

        public ProductBuilder SetCategory(string category)
        {
            _category = category;
            return this;
        }

        public Product Build()
        {
            return new Product(_imagePath, _name, _price, _category); // Создаем продукт
        }

        public ProductCard CreateProductCard()
        {
            var card = new ProductCard();
            var product = Build(); // Создаем продукт

            card.SetProduct(product); // Устанавливаем продукт в карточку
            return card;
        }
    }
}