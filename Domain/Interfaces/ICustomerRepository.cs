using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        public Task<Customer?> GetByEP(string email, string password);
    }
}
