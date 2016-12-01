using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCore.Csharp6Features.Models
{
    public class Product
    {
        public Product(bool stock = true)
        {
            Instock = stock;
        }
        public string Name { get; set; }
        public Decimal? Price { get; set; }

        public Product RelateProduct { get; set; }

        // auto assign default value
        public string Category { get; set; } = "WaterSport";

        // ready only property - but value can be change using constructor
        public bool Instock { get; }



        public static Product[] GetProduct()
        {
            Product kayak = new Product { Name="Kayak",Price=275M, Category="WaterCraft"};
            Product lifejacket = new Product { Name="LifeJacket",Price=48.95M};

            kayak.RelateProduct = lifejacket;

            return new Product[] { kayak, lifejacket, null };
        }
    }
}
