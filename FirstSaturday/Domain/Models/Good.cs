using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Good
    {
        public Good()
        {
            GoodFilterValues = new HashSet<GoodFilterValue>();
            OrderContents = new HashSet<OrderContent>();
        }

        public int GoodId { get; set; }
        public string Title { get; set; } = null!;
        public int CategotyId { get; set; }
        public decimal Price { get; set; }
        public int ManufacturerId { get; set; }
        public int AmountOnStock { get; set; }
        public byte[]? Photo { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Category Categoty { get; set; } = null!;
        public virtual Manufacturer Manufacturer { get; set; } = null!;
        public virtual ICollection<GoodFilterValue> GoodFilterValues { get; set; }
        public virtual ICollection<OrderContent> OrderContents { get; set; }
    }
}
