using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class GoodFilterValue
    {
        public int GoodId { get; set; }
        public int FilterId { get; set; }
        public object? FilterValue { get; set; }

        public virtual Filter Filter { get; set; } = null!;
        public virtual Good Good { get; set; } = null!;
    }
}
