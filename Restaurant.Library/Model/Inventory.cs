using Restaurant.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Model
{
    public class Inventory : IDataInventory
    {
        // link each product instance with one store
        public int InventoryId { get; set; }

        public int? Quantity { get; set; }
        public int? StoreId { get; set; }
        public int ProductId { get; set; }
    }
}
