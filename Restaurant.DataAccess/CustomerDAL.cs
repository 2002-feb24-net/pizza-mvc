using Restaurant.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Restaurant.DataAccess
{
    public class CustomerDAL
        //customer data access library
    {/*
        public void SaveCustomer(ICustomer customer)
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            var C_Customer = new Customers();
            // add BusinessLogic Customer to DbCustomer
            C_Customer.FullName = customer.FullName;
            C_Customer.Password = customer.Password;
            C_Customer.Username = customer.Username;


            context.Add(C_Customer);
            context.SaveChanges();
        }

        public List<Customers> LoadAllCustomers()
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            return context.Customers.ToList();

        }

        public Customers LoadCustomerByID(int customerID)
        {
            using DbRestaurantContext context = new DbRestaurantContext();

            var customersMatched = from customer in context.Customers
                                 where customer.CustomerId == customerID
                                 select customer;

            return customersMatched.First();
        }

        public List<Customers> LoadCustomersByName(string fullName)
        {
            using DbRestaurantContext context = new DbRestaurantContext();

            var customersMatched = from customer in context.Customers
                                   where customer.FullName == fullName
                                   select customer;

            return customersMatched.ToList();
        }

        public int GetCustomerID(string username, string password)
        {
            using DbRestaurantContext context = new DbRestaurantContext();
            var customerIDList = from customer in context.Customers
                           where username == customer.Username
                           && password == customer.Password
                           select customer.CustomerId;
            var customerID = customerIDList.FirstOrDefault(); // unique combination so can return single, no duplicates possible from db
            return customerID;
        }*/
    }
}
