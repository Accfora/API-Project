using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string? City { get; set; }
        public string? TelephoneNumber { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
