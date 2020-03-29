using System;
using System.Collections.Generic;

namespace Restaurant.DataAccess.Models
{
    public partial class Stores
    {
        public Stores()
        {
            Inventorys = new HashSet<Inventorys>();
            Orders = new HashSet<Orders>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        public virtual ICollection<Inventorys> Inventorys { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
