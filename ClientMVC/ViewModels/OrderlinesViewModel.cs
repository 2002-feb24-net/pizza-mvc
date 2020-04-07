using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientMVC.ViewModels
{
    public partial class OrderlinesViewModel
    {
        public int OrderlineId { get; set; }

        [Required]
        [Display (Name = "Product ID")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual OrdersViewModel Order { get; set; }
        public virtual ProductsViewModel Product { get; set; }
    }
}
