using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        Task Save();
        ICustomerRepository Customer { get; }
        IOrderRepository Order { get; }
        IOrderContentRepository OrderContent { get; }
        IGoodRepository Good { get; }
        IManufacturerRepository Manufacturer { get; }
        ICategoryRepository Category { get; }
        IFilterRepository Filter { get; }
        IGoodFilterValueRepository GoodFilterValue { get; }

    }
}
