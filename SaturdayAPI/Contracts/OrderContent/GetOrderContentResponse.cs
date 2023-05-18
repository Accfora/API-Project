namespace SaturdayAPI.Contracts.OrderContent
{
    public class GetOrderContentResponse
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int GoodId { get; set; }
        public int NumberOfPositions { get; set; }
    }
}
