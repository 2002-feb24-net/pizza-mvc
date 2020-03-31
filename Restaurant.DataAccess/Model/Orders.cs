using System;
using System.Collections.Generic;

namespace Restaurant.DataAccess.Model
{
    public partial class Orders
    {
        public Orders()
        {
            Orderlines = new HashSet<Orderlines>();
        }

        public int OrderId { get; set; }
        public decimal? Total { get; set; }
        public DateTime TimeOrdered { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Stores Store { get; set; }
        public virtual ICollection<Orderlines> Orderlines { get; set; }
    }
}
