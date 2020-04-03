using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DataAccess.Repositories
{
    public class OrderRepository : Repository<Orders>
    {
        public OrderRepository()
        {
        }

        /*OrdersByCustomerId(string CustomerId)
        {
            var listOfOrders = _context.Orders.Where(x => x.CustomerId == customer.CustomerId).Include("Orderlines"); // grab an type
        }*/
    }
}
