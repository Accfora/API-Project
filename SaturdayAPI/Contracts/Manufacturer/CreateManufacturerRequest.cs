namespace SaturdayAPI.Contracts.Manufacturer
{
    public class CreateManufacturerRequest
    {
        public int ManufacturerId { get; set; } //Поле оставлено, так как в базе данных без автоинкремента
        public string ManufacturerName { get; set; } = null!;
        public string ManufacturerCountry { get; set; } = null!;
    }
}
