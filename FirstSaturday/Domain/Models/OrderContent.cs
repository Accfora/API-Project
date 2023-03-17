using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class OrderContent
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int GoodId { get; set; }
        public int NumberOfPositions { get; set; }

        public virtual Good Good { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
