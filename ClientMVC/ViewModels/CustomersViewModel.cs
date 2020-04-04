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

        public int CustomerId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<OrdersViewModel> Orders { get; set; }
    }
}
