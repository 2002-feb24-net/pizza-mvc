using System;
using System.Collections.Generic;

namespace ClientMVC.ViewModels
{
    public partial class CustomersViewModel
    {
        public CustomersViewModel()
        {
            Orders = new HashSet<OrdersViewModel>();
        }

        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<OrdersViewModel> Orders { get; set; }
    }
}
