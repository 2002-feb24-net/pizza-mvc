using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using Restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.DataAccess
{
    public class StoreDAL
    //customer data access library
    {
        public void SaveStore(IDataStore store)
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            var S_Stores = new Stores();
            // add BusinessLogic Store to DbStores
            S_Stores.StoreName = store.StoreName;
            S_Stores.StreetAddress = store.StreetAddress;
            S_Stores.City = store.City;
            S_Stores.State = store.State;
            S_Stores.Zipcode = store.Zipcode;


            context.Add(S_Stores);
            context.SaveChanges();
        }

        public void InitializeStore(Stores S_Stores, IDataStore store)
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            store.StoreName = S_Stores.StoreName;
            store.StreetAddress = S_Stores.StreetAddress;
            store.City = S_Stores.City;
            store.State = S_Stores.State;
            store.Zipcode = S_Stores.Zipcode;
            store.StoreId = S_Stores.StoreId;
        }

        public List<Stores> LoadAllStores()
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            return context.Stores.ToList();

        }

        public Stores LoadStoreByID(int storeID)
        {
            using DbRestaurantContext context = new DbRestaurantContext();

            var storeMatched = from store in context.Stores
                               where store.StoreId == storeID
                               select store;

            return storeMatched.First();
        }
    }
}
