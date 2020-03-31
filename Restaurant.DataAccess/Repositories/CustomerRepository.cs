using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DataAccess
{
    public class CustomerRepository : Repository<Customers>
    {
        public CustomerRepository(DbContext context) : base(context)
        {
        }

        /*public List<Customers> LoadCustomersByName(string fullName)
        {
            using DbRestaurantContext context = new DbRestaurantContext();

            var customersMatched = from customer in context.Customers
                                   where customer.FullName == fullName
                                   select customer;

            return customersMatched.ToList();
        }*/
    }
}
