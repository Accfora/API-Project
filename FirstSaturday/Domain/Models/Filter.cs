using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Filter
    {
        public Filter()
        {
            GoodFilterValues = new HashSet<GoodFilterValue>();
        }

        public int FilterId { get; set; }
        public int CategoryId { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<GoodFilterValue> GoodFilterValues { get; set; }
    }
}
