using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientMVC.ViewModels
{
    public partial class StoresViewModel
    {
        public StoresViewModel()
        {
            Inventorys = new HashSet<InventorysViewModel>();
            Orders = new HashSet<OrdersViewModel>();
        }
        public int StoreId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]

        public string StoreName { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        [DataType(DataType.MultilineText)]
        public string StreetAddress { get; set; }
        [Required]
        [DataType(DataType.Text)]

        public string City { get; set; }
        [Required]
        [DataType(DataType.Text)]

        public string State { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        public virtual ICollection<InventorysViewModel> Inventorys { get; set; }
        public virtual ICollection<OrdersViewModel> Orders { get; set; }
    }
}
