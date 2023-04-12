namespace SaturdayAPI.Contracts.Customer
{
    public class GetManufacturerResponse
    {
        public int ManufacturerId { get; set; }
        public string ManufacturerName { get; set; } = null!;
        public string ManufacturerCountry { get; set; } = null!;
    }
}
