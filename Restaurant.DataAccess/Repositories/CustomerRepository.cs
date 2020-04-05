using Microsoft.EntityFrameworkCore;
using Restaurant.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Restaurant.DataAccess.Repositories
{
    public class CustomerRepository : Repository<Customers>
    {
        public CustomerRepository()
        {
        }

        HashSet<Customers> GetCustomers(Stores store)
        {
            using var context2 = new DbRestaurantContext();
            var listOfCustomers = from order in context2.Orders
                                  join customer in context2.Customers
    on order.CustomerId equals customer.CustomerId
                                  where order.StoreId == store.StoreId
                                  select customer;
            HashSet<Customers> setOfCustomers = new HashSet<Customers>(listOfCustomers);
            return setOfCustomers;
        }

        List<Domain.Model.Customer> GetAllCustomers()
        {
            var listOfCustomers = GetAll().ToList();

            var domain_listOfCustomers = new List<Domain.Model.Customer>();

            foreach (var customer in listOfCustomers)
            {
                domain_listOfCustomers.Add(Mapper.MapCustomer(customer));

            }

            return domain_listOfCustomers;

        }

        public IEnumerable<Customers> GetContains(string sString = null) //default null value
        {
            var customers = GetAll();

            if (sString != null)
            {
                customers = customers.Where(c => c.FullName.Contains(sString));
            }

            return customers;
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
