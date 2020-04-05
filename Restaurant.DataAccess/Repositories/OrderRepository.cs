using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Restaurant.DataAccess.Repositories
{
    public class OrderRepository : Repository<Orders>
    {
        DbRestaurantContext context = new DbRestaurantContext();
        public OrderRepository()
        {
        }

        public List<Orders> GetAllOrdersIncludeCustomerAndStore()
        {
            var listOfOrders = context.Orders.Include(o => o.Customer).Include(o => o.Store);

            return listOfOrders.ToList();
        }
        public List<Orders> GetAllOrdersIncludeAll()
        {
            var listOfOrders = context.Orders.Include(o => o.Customer).Include(o => o.Store).Include(o => o.Orderlines);

            return listOfOrders.ToList();
        }

        public Orders GetOrderWithDetails(int orderId)
        {
            return context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Store)
                .Include(o => o.Orderlines)
                .ThenInclude(or => or.Product)
                .FirstOrDefault(m => m.OrderId == orderId);
        }

        public IEnumerable<Orders> GetContains(string sString = null) //default null value
        {
            IEnumerable<Orders> orders = GetAllOrdersIncludeAll();

            if (sString != null)
            {
                orders = orders.Where(c => c.Customer.FullName.Contains(sString) || c.Store.StoreName.Contains(sString));
            }

            return orders;
        }

        /*OrdersByCustomerId(string CustomerId)
        {
            var listOfOrders = _context.Orders.Where(x => x.CustomerId == customer.CustomerId).Include("Orderlines"); // grab an type
        }*/
    }
}
