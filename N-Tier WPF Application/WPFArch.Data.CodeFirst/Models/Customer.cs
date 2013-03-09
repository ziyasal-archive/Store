using System.Collections.Generic;

namespace WPFArch.Data.CodeFirst.Models
{
    public sealed class Customer
    {
        public Customer()
        {
            Orders = new List<Order>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
