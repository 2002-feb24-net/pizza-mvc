using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Interface
{
    public interface IDataOrder
    {
        public int OrderId { get; set; }
        public decimal? Total { get; set; }
        public DateTime TimeOrdered { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }
    }
}
