namespace SaturdayAPI.Contracts.Customer
{
    public class CreateGoodRequest
    {
        public int GoodId { get; set; } //Поле оставлено, так как в базе данных без автоинкремента
        public string Title { get; set; } = null!;
        public int CategotyId { get; set; }
        public decimal Price { get; set; }
        public int ManufacturerId { get; set; }
        public int AmountOnStock { get; set; }
    }
}
