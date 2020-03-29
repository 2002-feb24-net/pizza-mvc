using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Models;
using Restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.DataAccess
{
    public class ProductDAL
        //customer data access library
    {
        public void SaveProduct(IDataProduct product)
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            var P_Products = new Products();
            // add BusinessLogic Customer to DbCustomer
            P_Products.ProductName = product.ProductName;
            P_Products.Cost = product.Cost;


            context.Add(P_Products);
            context.SaveChanges();
        }

        public List<Products> LoadAllProducts()
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            return context.Products.ToList();

        }

        public List<int> LoadProductIDsFromStoreInStock(IDataStore store)
        {
            using DbRestaurantContext context = new DbRestaurantContext();


            // inventory links to both products and store(s)
            // filter by the store id
            // select all products where storeid = store.storeID

            var storeId = store.StoreId;

            var productIDsInStock = from inventorys in context.Inventorys
                                  where inventorys.StoreId == storeId
                                  select inventorys.ProductId;
            
            return new List<int>(productIDsInStock);
            

        }

        public List<int> LoadProductIDsFromStoreInStock(Stores store)
        {
            using DbRestaurantContext context = new DbRestaurantContext();


            // inventory links to both products and store(s)
            // filter by the store id
            // select all products where storeid = store.storeID

            var storeId = store.StoreId;

            var productIDsInStock = from inventorys in context.Inventorys
                                    where inventorys.StoreId == storeId
                                    select inventorys.ProductId;

            return new List<int>(productIDsInStock);


        }

        /* public List<string> LoadProductNamesFromStoreInStock(IDataStore store)
         {
             using DbRestaurantContext context = new DbRestaurantContext();


             // inventory links to both products and store(s)
             // filter by the store id
             // select all products where storeid = store.storeID

             var storeId = store.StoreId;

             var productIDsInStock = from inventorys in context.Inventorys
                                     where inventorys.StoreId == storeId
                                     select inventorys.ProductId;
             // these are the product ids, but we need the names as well for most uses

             /* IQueryable<string> productNamesInStock;
              foreach (var productID in productIDsInStock)
              {
                  productNamesInStock = from products in context.Products where products.ProductId == productID select products.ProductName;
              }


               Error: list of strings stays empty*/

        /* throw new NotImplementedException();


     }*/

        public Products LoadProductByID(int productID)
        {
            using DbRestaurantContext context = new DbRestaurantContext();

            var productMatched = from product in context.Products
                                 where product.ProductId == productID
                                 select product;

            return productMatched.First();
        }
    }
}
