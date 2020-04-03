using Microsoft.EntityFrameworkCore;
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
