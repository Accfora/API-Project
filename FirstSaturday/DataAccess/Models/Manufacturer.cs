using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Goods = new HashSet<Good>();
        }

        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string ManufacturerCountry { get; set; } = null!;
        public DateTime? DeletedAt { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
