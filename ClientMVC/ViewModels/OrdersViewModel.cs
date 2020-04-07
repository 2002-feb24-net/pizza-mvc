using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientMVC.ViewModels
{
    public partial class OrdersViewModel
    {
        public OrdersViewModel()
        {
            Orderlines = new HashSet<OrderlinesViewModel>();
        }

        public int OrderId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal? Total { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display (Name = "Time Ordered")]
        public DateTime TimeOrdered { get; set; }

        [Required]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Store ID")]
        public int StoreId { get; set; }

        public virtual CustomersViewModel Customer { get; set; }
        public virtual StoresViewModel Store { get; set; }
        public virtual ICollection<OrderlinesViewModel> Orderlines { get; set; }
    }
}
