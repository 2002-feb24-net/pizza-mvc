using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataAccess.Model
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        [Display (Name = "Customer ID")]
        public int CustomerId { get; set; }
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.Text)]

        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
