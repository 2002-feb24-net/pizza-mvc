using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataAccess.Model
{
    public partial class Orders
    {
        public Orders()
        {
            Orderlines = new HashSet<Orderlines>();
        }

        public int OrderId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal? Total { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Time Ordered")]
        public DateTime TimeOrdered { get; set; }

        [Required]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Store ID")]
        public int StoreId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual Stores Store { get; set; }
        public virtual ICollection<Orderlines> Orderlines { get; set; }
    }
}
