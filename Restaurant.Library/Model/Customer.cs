using System;
using System.Collections.Generic;
using System.Text;
using Restaurant.Interface;

namespace Restaurant.Domain.Model
{
    public class Customer : User, ICustomer
    {
        // implements username and password validation from User
        // have to override username methods because using Full name ("FirstName LastName")
        // otherwise methods would talk about username when user inputs full name
        public string FullName
        {
            get;
            set;
        }

        public int CustomerId { get; set; }

        public Customer( string fullname)
            // registers a customer, can load data from existing customer in db
        {
            FullName = fullname;
           
            /*Username = uniqueUsername;
            Password = password;*/

        }

        static string SearchCustomerByName (string cname)
        {
            //connect to database get loaded list
            throw new NotImplementedException();
        }

        


    }
}
