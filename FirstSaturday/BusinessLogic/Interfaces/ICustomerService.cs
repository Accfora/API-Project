using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task Create(Customer model);
        Task Update(Customer model);
        Task Delete(int id);
    }
}
