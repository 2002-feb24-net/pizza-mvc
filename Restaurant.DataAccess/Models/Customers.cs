using System;
using System.Collections.Generic;

namespace Restaurant.DataAccess.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
