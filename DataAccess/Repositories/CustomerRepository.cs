using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(LContext repositoryContext) : base(repositoryContext) { }
    }
}
