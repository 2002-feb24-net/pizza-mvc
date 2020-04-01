using System;

namespace Restaurant.Domain.Interfaces
{
    public interface ICustomer
    {
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
