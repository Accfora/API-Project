﻿namespace SaturdayAPI.Contracts.Customer
{
    public class GetCategoryResponse
    {
        public int CategotyId { get; set; }
        public string CategotyName { get; set; } = null!;
        public int? ParentCategory { get; set; }
    }
}
