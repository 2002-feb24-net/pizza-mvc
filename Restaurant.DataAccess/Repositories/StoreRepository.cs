using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Restaurant.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataAccess.Repositories
{
    public class StoreRepository : Repository<Stores>
    {
        public StoreRepository()
        {
        }

        public Dictionary<Inventorys, Products> GetProductsInStock(int storeId)
        {
            /* using var _context = new DbRestaurantContext();

             var listOfStoresAndProducts = _context.Stores.Include(s => s.StoreId == storeId)
                                                 .Include(i => i.Inventorys)
                                                 .ThenInclude(p => p.Product);
             // cannot return an iqueryable without a string so need to convert to dictionary
             Dictionary<Inventorys, Products> storesInvAndProducts = new Dictionary<Inventorys, Products>();
             foreach (var store in listOfStoresAndProducts)
             {
                 storesInvAndProducts.Add(store.Inventorys, store.Inventorys.)
             }

             return listOfProducts;*/


            // need inventorys and then need products matching those inventory.products

            using var context = new DbRestaurantContext();

            var storeIncludingInventorys = context.Stores.Include(s => s.StoreId == storeId)
                                                 .Include(i => i.Inventorys).FirstOrDefault();

            var inventorys = context.Inventorys.Where(i => i.StoreId == storeId).Include(p => p.Product);

            // convert to dictionary
            var inventorysAndProducts = new Dictionary<Inventorys, Products>();
            foreach (var inventory in inventorys)
            {
                inventorysAndProducts.Add(inventory, inventory.Product);
            }

            return inventorysAndProducts;

        }

        public IEnumerable<Stores> GetContains(string sString = null) //default null value
        {
            var stores = GetAll();

            if (sString != null)
            {
                stores = stores.Where(c => c.StoreName.Contains(sString));
            }

            return stores;
        }

        public List<Domain.Model.Store> GetAllDomainStores ()
        {
            var _context = new DbRestaurantContext();
            var listOfStores = _context.Stores.Include("Inventorys").Include("Orders.Orderlines.Product").Include("Orders.Customer");
            
            List<Domain.Model.Store> domain_listOfStores = new List<Domain.Model.Store>();

            foreach (var store in listOfStores)
            {
                domain_listOfStores.Add(Mapper.MapStoreWithDetails(store));
            }
            return domain_listOfStores;
        }

        public Domain.Model.Store GetDomainStore(int storeId)
        {
            var _context = new DbRestaurantContext();
            var data_store = _context.Stores.Include("Inventorys").Include("Orders.Orderlines.Product").Include("Orders.Customer").SingleOrDefault(s => s.StoreId == storeId);
            


     
                return Mapper.MapStoreWithDetails(data_store);
            
        }
    }
}
