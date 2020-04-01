using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Interfaces
{
    public interface IDataProduct
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? Cost { get; set; }
    }
}
