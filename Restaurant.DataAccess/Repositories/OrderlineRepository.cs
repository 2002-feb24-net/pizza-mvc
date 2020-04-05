using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataAccess.Repositories
{
    public class OrderlineRepository : Repository<Orderlines>
    {
        DbRestaurantContext context = new DbRestaurantContext();
        public OrderlineRepository()
        {
        }

        public IEnumerable<Orderlines> GetAllOrderlinesIncludeAll()
        {
            var listOfOrders = context.Orderlines.Include(o => o.Order).Include(o => o.Product);

            return listOfOrders.ToList();
        }

        public Orderlines GetOrderlineIncludeAll(int? id)
        {
            var orderline = context.Orderlines
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefault(m => m.OrderlineId == id);

            return orderline;
        }




    }
}
