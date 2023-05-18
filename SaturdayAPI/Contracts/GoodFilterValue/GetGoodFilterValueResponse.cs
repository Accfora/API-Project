namespace SaturdayAPI.Contracts.GoodFilterValue
{
    public class GetGoodFilterValueResponse
    {
        public int GoodId { get; set; }
        public int FilterId { get; set; }
        public object? FilterValue { get; set; }
    }
}
