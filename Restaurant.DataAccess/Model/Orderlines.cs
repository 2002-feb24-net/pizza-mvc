using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataAccess.Model
{
    public partial class Orderlines
    {
        public int OrderlineId { get; set; }

        [Required]
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
