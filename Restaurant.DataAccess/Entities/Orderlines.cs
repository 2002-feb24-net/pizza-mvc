using System;
using System.Collections.Generic;

namespace Restaurant.DataAccess.Entities
{
    public partial class Orderlines
    {
        public int OrderlineId { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
