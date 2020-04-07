using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.DataAccess.Model
{
    public partial class Stores
    {
        public Stores()
        {
            Inventorys = new HashSet<Inventorys>();
            Orders = new HashSet<Orders>();
        }

        public int StoreId { get; set; }
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]

        public string StoreName { get; set; }
        [Required]
        [Display(Name = "Street Address")]
        [DataType(DataType.MultilineText)]
        public string StreetAddress { get; set; }
        [Required]
        [DataType(DataType.Text)]

        public string City { get; set; }
        [Required]
        [DataType(DataType.Text)]

        public string State { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string Zipcode { get; set; }

        public virtual ICollection<Inventorys> Inventorys { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
