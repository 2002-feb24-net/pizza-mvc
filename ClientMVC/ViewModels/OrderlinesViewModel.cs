using System;
using System.Collections.Generic;

namespace ClientMVC.ViewModels
{
    public partial class OrderlinesViewModel
    {
        public int OrderlineId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual OrdersViewModel Order { get; set; }
        public virtual ProductsViewModel Product { get; set; }
    }
}
