namespace SaturdayAPI.Contracts.Customer
{
    public class GetOrderResponse
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool Paid { get; set; }
        public int? DeliveryType { get; set; }
    }
}
