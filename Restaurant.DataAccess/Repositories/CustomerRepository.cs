using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.DataAccess.Repositories
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
