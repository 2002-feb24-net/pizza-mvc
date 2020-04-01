using Restaurant.Interface;
using System;
using System.Collections.Generic;

namespace Restaurant.Domain.Model
{
    public class Product : IDataProduct
    {
        // make an object to hold hot wings and price, cola drink and price
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Cost { get; set; }

        // previously had a dictionary, but the class already links Name and Price so do not need a dictionary

        public Product (string name, decimal? price)
        {
            ProductName = name;
            Cost = price;

            //DecrementInventory();
        }






    }
}
