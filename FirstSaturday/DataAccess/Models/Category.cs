using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            Filters = new HashSet<Filter>();
            Goods = new HashSet<Good>();
            InverseParentCategoryNavigation = new HashSet<Category>();
        }

        public int CategotyId { get; set; }
        public string CategotyName { get; set; } = null!;
        public int? ParentCategory { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Category? ParentCategoryNavigation { get; set; }
        public virtual ICollection<Filter> Filters { get; set; }
        public virtual ICollection<Good> Goods { get; set; }
        public virtual ICollection<Category> InverseParentCategoryNavigation { get; set; }
    }
}
