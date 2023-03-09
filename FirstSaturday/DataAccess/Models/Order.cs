using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderContents = new HashSet<OrderContent>();
        }

        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
        public int? DeliveryType { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<OrderContent> OrderContents { get; set; }
    }
}
