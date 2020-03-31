using System;
using System.Collections.Generic;

namespace Restaurant.DataAccess.Model
{
    public partial class Products
    {
        public Products()
        {
            Inventorys = new HashSet<Inventorys>();
            Orderlines = new HashSet<Orderlines>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Cost { get; set; }

        public virtual ICollection<Inventorys> Inventorys { get; set; }
        public virtual ICollection<Orderlines> Orderlines { get; set; }
    }
}
