using DataAccess.Interfaces;

namespace DataAccess.Wrapper
{
    public interface IRepositoryWrapper
    {
        void Save();
        ICustomerRepository Customer { get; }
        IGoodRepository Good { get; }
    }
}
