using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientMVC.ViewModels
{
    public class CustomersViewModel
    {
        public CustomersViewModel()
        {
            Orders = new HashSet<OrdersViewModel>();
        }

        [Display(Name = "Customer ID")]
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

        public virtual ICollection<OrdersViewModel> Orders { get; set; }
    }
}
