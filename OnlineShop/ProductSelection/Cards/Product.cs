namespace OnlineShop.ProductSelection.Cards
{
    public class Product
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }

        public Product(string imagePath, string name, string price, string category)
        {
            ImagePath = imagePath;
            Name = name;
            Price = price;
            Category = category;
        }
    }
}