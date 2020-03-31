using System;
using System.Collections.Generic;

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
        public string StoreName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<InventorysViewModel> Inventorys { get; set; }
        public virtual ICollection<OrdersViewModel> Orders { get; set; }
    }
}
