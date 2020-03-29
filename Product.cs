using System;
using System.Collections.Generic;

namespace harold_project0
{
    class Product
    {
        // make an object to hold wings and prices, drinks and prices
        public Dictionary<string, decimal> ProductAndPrices
        {
            get
            {
                return ProductAndPrices;
            }

            set
            {
                foreach (var entry in value)
                {
                    ProductAndPrices.Add(entry.Key, entry.Value);
                }
            }
        }
        public Product(Dictionary<string, decimal> productAndPrices)
        {
            // ex: Product wings = {spicy eight count, 10}, {mild eight count, 10}
            ProductAndPrices = productAndPrices;
            // never empty wings/drinks list bc in constructor
        }

        //public Stock

        
    }
}
