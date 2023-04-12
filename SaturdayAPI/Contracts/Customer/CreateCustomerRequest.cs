namespace SaturdayAPI.Contracts.Customer
{
    public class CreateCustomerRequest
    {
        public int CustomerId { get; set; } //Поле оставлено, так как в базе данных без автоинкремента
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string? City { get; set; }
        public string? TelephoneNumber { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
