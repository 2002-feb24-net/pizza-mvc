using System;
using System.Collections.Generic;

namespace Restaurant.DataAccess.Models
{
    public partial class Inventorys
    {
        public int InventoryId { get; set; }
        public int? Quantity { get; set; }
        public int? StoreId { get; set; }
        public int ProductId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Stores Store { get; set; }
    }
}
