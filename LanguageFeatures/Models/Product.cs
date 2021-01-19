using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            inStock = stock;
        }

        public string Name { get; set; }
        public string Category { get; set; } = "WaterSports";
        public decimal? Price { get; set; }
        public Product Related { get; set; }        //т.к это Product Related, то я могу к любому продукту
        public bool inStock { get; } = true;       //использовать Product.Related = value;
        public static Product[] GetProducts()
        {
            Product kayak = new Product
            {
                Name = "Kayak",
                Price = 275M
            };
            Product lifejacket = new Product(false)
            {
                Name = "Lifejacket",
                Category = "Water Craft",
                Price = 48.95M
            };

            kayak.Related = lifejacket;
            //на основании поля Product.Related связали каяк и жилет

            return new Product[] { kayak, lifejacket, null };
        }
    }
}
