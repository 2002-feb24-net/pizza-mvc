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

        public static DataAccess.Model.Products MapProduct(Domain.Model.Product data_products)
        {
            return new DataAccess.Model.Products()
            {
                ProductId = data_products.ProductId,
                ProductName = data_products.ProductName,
                Cost = data_products.Cost
            };
            // constructor requires a string name and a price

        }

        public static Domain.Model.Inventory MapInventory(DataAccess.Model.Inventorys data_inventory)
        {
            return new Domain.Model.Inventory()
            {
                InventoryId = data_inventory.InventoryId,
                ProductId = data_inventory.Product.ProductId,
                Product = MapProduct(data_inventory.Product),
                Quantity = data_inventory.Quantity,
                StoreId = data_inventory.StoreId
                
            };

        }

        public static DataAccess.Model.Inventorys MapInventory(Domain.Model.Inventory domain_inventory)
        {
            return new DataAccess.Model.Inventorys()
            {
                InventoryId = domain_inventory.InventoryId,
                ProductId = domain_inventory.Product.ProductId,
                Product = MapProduct(domain_inventory.Product),
                Quantity = domain_inventory.Quantity,
                StoreId = domain_inventory.StoreId

            };

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
            

            foreach (var inventory in data_stores.Inventorys)
            {
                tempStore.ProductAndInventory.Add(MapProduct(inventory.Product), MapInventory(inventory));

            }

            return tempStore; // initialized domain model store

        }

        public static DataAccess.Model.Stores  MapStoreWithInventory(Domain.Model.Store domain_store)
        {
            /*var MapOrderWithDetails(data_stores.Orders);*/
            var tempStore = new DataAccess.Model.Stores
            {
                StoreName = domain_store.StoreName,
                StreetAddress = domain_store.StreetAddress,
                City = domain_store.City,
                State = domain_store.State,
                Zipcode = domain_store.Zipcode,
                StoreId = domain_store.StoreId

            };
            //add inventory for each item sold

            foreach (var item in domain_store.ProductAndInventory)
            {
                var tempInventory = Mapper.MapInventory(item.Value);


                tempStore.Inventorys.Add(tempInventory);
                // product data lost?
            }



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

            //add inventory for each item sold

            foreach (var inventory in data_stores.Inventorys)
            {
                tempStore.ProductAndInventory.Add(MapProduct(inventory.Product), MapInventory(inventory));
            }

            //add past customers (customers who have place orders at this store before)
            foreach (var order in data_stores.Orders)
            {
                tempStore.PastCustomers.Add(MapCustomer(order.Customer));
            }

            return tempStore; // initialized domain model store

        }


    }
}
