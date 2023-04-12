namespace SaturdayAPI.Contracts.Customer
{
    public class GetGoodResponse
    {
        public int GoodId { get; set; }
        public string Title { get; set; } = null!;
        public int CategotyId { get; set; }
        public decimal Price { get; set; }
        public int ManufacturerId { get; set; }
        public int AmountOnStock { get; set; }
    }
}
