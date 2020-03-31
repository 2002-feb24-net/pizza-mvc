using System;
using System.Collections.Generic;

namespace ClientMVC.ViewModels
{
    public partial class ProductsViewModel
    {
        public ProductsViewModel()
        {
            Inventorys = new HashSet<InventorysViewModel>();
            Orderlines = new HashSet<OrderlinesViewModel>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Cost { get; set; }

        public virtual ICollection<InventorysViewModel> Inventorys { get; set; }
        public virtual ICollection<OrderlinesViewModel> Orderlines { get; set; }
    }
}
