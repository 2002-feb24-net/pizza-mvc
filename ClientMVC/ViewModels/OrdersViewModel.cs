using System;
using System.Collections.Generic;

namespace ClientMVC.ViewModels
{
    public partial class OrdersViewModel
    {
        public OrdersViewModel()
        {
            Orderlines = new HashSet<OrderlinesViewModel>();
        }

        public int OrderId { get; set; }
        public decimal? Total { get; set; }
        public DateTime TimeOrdered { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }

        public virtual CustomersViewModel Customer { get; set; }
        public virtual StoresViewModel Store { get; set; }
        public virtual ICollection<OrderlinesViewModel> Orderlines { get; set; }
    }
}
