using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataAccess.Repositories
{
    public class InventoryRepository : Repository<Inventorys>
    {
        DbRestaurantContext context = new DbRestaurantContext();
        public InventoryRepository()
        {
        }

        
    }
}
