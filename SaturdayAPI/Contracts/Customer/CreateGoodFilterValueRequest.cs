namespace SaturdayAPI.Contracts.Customer
{
    public class CreateGoodFilterValueRequest
    {
        public int GoodId { get; set; }
        public int FilterId { get; set; }
        public object? FilterValue { get; set; }
    }
}
