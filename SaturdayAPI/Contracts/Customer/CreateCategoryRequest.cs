namespace SaturdayAPI.Contracts.Customer
{
    public class CreateCategoryRequest
    {
        public int CategotyId { get; set; } //Поле оставлено, так как в базе данных без автоинкремента
        public string CategotyName { get; set; } = null!;
        public int? ParentCategory { get; set; }
    }
}
