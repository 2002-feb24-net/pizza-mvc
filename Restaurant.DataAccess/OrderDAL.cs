using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Models;
using Restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Restaurant.DataAccess
{
    public class OrderDAL
        //customer data access library
    {
        public void SaveOrder(IDataOrder order, ICustomer customer, IDataStore store)
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            var O_Orders = new Orders();
            // add BusinessLogic Order to DBOrders
            O_Orders.CustomerId = customer.CustomerId;
            O_Orders.StoreId = store.StoreId;
            O_Orders.Total = order.Total;

            O_Orders.TimeOrdered = DateTime.Now; // local time


            context.Add(O_Orders);
            context.SaveChanges();
        }

        public void SaveOrder(Orders order, ICustomer customer, IDataStore store)
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            var O_Orders = new Orders();
            // add BusinessLogic Order to DBOrders
            O_Orders.CustomerId = customer.CustomerId;
            O_Orders.StoreId = store.StoreId;
            O_Orders.Total = order.Total;

            O_Orders.TimeOrdered = DateTime.Now; // local time


            context.Add(O_Orders);
            context.SaveChanges();
        }

        public List<Orders> LoadOrders()
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            return context.Orders.Include("Orderlines").Include("Customers").ToList();
        }
    }
}
