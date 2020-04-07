using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [Display(Name = "Product")]
        public string ProductName { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal? Cost { get; set; }

        public virtual ICollection<InventorysViewModel> Inventorys { get; set; }
        public virtual ICollection<OrderlinesViewModel> Orderlines { get; set; }
    }
}
