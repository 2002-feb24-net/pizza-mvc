using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Interface
{
    public interface IDataInventory
    {
        public int InventoryId { get; set; }
        public int? Quantity { get; set; }
        public int? StoreId { get; set; }
        public int ProductId { get; set; }
    }
}
