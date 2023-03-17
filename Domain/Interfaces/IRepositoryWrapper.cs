using Domain.Interfaces;

namespace Domain.Interfaces
{
    public interface IRepositoryWrapper
    {
        Task Save();
        ICustomerRepository Customer { get; }
        IGoodRepository Good { get; }
    }
}
