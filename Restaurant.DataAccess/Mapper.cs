using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataAccess
{
    public static class Mapper
    {
        public static Domain.Model.Order MapOrderWithDetails(DataAccess.Model.Orders data_orders)
        {
            var tempOrder = new Domain.Model.Order(MapCustomer(data_orders.Customer))
            {
                OrderId = data_orders.OrderId,


            };
            foreach (var orderline in data_orders.Orderlines)
            {
                var tempProduct = MapProduct(orderline.Product);
                tempOrder.AllProductsOnOrder.Add(tempProduct);

            }


            return tempOrder;
        }

        public static Domain.Model.Product MapProduct(DataAccess.Model.Products data_products)
        {
            return new Domain.Model.Product(data_products.ProductName, data_products.Cost)
            {
                ProductId = data_products.ProductId
            };
            // constructor requires a string name and a price

        }
        internal static Domain.Model.Customer MapCustomerWithLoginDetails(DataAccess.Model.Customers data_customers)
        {
            return new Domain.Model.Customer(data_customers.FullName)
            {
                Password = data_customers.Password,
                Username = data_customers.Username
            };
        }

        internal static Domain.Model.Customer MapCustomer(DataAccess.Model.Customers data_customers)
        {
            return new Domain.Model.Customer(data_customers.FullName);
        }

        // The passed Stores object must include Inventorys or the inventory quantity will be null
        public static Domain.Model.Store MapStoreWithInventory(DataAccess.Model.Stores data_stores)
        {
            /*var MapOrderWithDetails(data_stores.Orders);*/
            var tempStore = new Domain.Model.Store
            {
                StoreName = data_stores.StoreName,
                StreetAddress = data_stores.StreetAddress,
                City = data_stores.City,
                State = data_stores.State,
                Zipcode = data_stores.Zipcode,
                StoreId = data_stores.StoreId
            
            };
            //get inventory matching storeid
             var data_storeInv = data_stores.Inventorys.FirstOrDefault();


            tempStore.ProductAndInventory.Add(MapProduct(data_storeInv.Product), Convert.ToInt32(data_storeInv.Quantity));

            return tempStore; // initialized domain model store

        }

        public static Domain.Model.Store MapStoreWithDetails(DataAccess.Model.Stores data_stores)
        {
            /*var MapOrderWithDetails(data_stores.Orders);*/
            var tempStore = new Domain.Model.Store
            {
                StoreName = data_stores.StoreName,
                StreetAddress = data_stores.StreetAddress,
                City = data_stores.City,
                State = data_stores.State,
                Zipcode = data_stores.Zipcode,
                StoreId = data_stores.StoreId

            };
            //get inventory matching storeid
            var data_storeInv = data_stores.Inventorys.FirstOrDefault();

            //add inventory for each item sold
            tempStore.ProductAndInventory.Add(MapProduct(data_storeInv.Product), Convert.ToInt32(data_storeInv.Quantity));

            //add past customers (customers who have place orders at this store before)
            foreach (var order in data_stores.Orders)
            {
                tempStore.PastCustomers.Add(MapCustomer(order.Customer));
            }

            return tempStore; // initialized domain model store

        }


    }
}
