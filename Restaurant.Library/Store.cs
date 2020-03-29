using Restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Library
{
    public class Store : IDataStore
    {
        public string StreetAddress { get; set; }
        public int StoreId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string StoreName { get; set; }

        List<Product> ProductsSold { get; set; }
        // to avoid someone trying to order burgers from Pizza restaurant
        // need only check Product.Name for verification, but added whole product class to allow different operations
        // for example: can list all products of x price

            // Quantity of Inventory for each product
        Dictionary<Product,int> ProductAndInventory { 
            get { return ProductAndInventory; }
            set 
            {
                // verify items cost at least 0
                // else throw an exception

                foreach (var item in value)
                {
                    if (item.Value < 0)
                    {
                        throw new ArgumentOutOfRangeException($"Cannot have negative inventory for product: {item.Key}");
                    }


                }
            }
        }


    }
}
