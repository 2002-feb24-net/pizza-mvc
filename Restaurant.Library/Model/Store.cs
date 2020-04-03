using Restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Model
{
    public class Store : IDataStore
    {
        public string StreetAddress { get; set; }
        public int StoreId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string StoreName { get; set; }


        public Store()
        {

        }



        public List<Product> ProductsSold { get; set; } = new List<Product>();
        // to avoid someone trying to order burgers from Pizza restaurant
        // need only check Product.Name for verification, but added whole product class to allow different operations
        // for example: can list all products of x price

        // Quantity of Inventory for each product

        public List<Customer> PastCustomers { get; set; } = new List<Customer>();
        // customers who have bought something at this store before

        public List<Order> PastOrders { get; set; } = new List<Order>();

        private Dictionary<Product, int> _ProductAndInventory = new Dictionary<Product, int>();
        public Dictionary<Product,int> ProductAndInventory {
            get
            {
                return _ProductAndInventory;
            }
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
                    else
                        _ProductAndInventory.Add(item.Key, item.Value);


                }
            } 
        }


    }
}
