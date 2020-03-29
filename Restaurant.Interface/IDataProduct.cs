using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Interface
{
    public interface IDataProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Cost { get; set; }
    }
}
