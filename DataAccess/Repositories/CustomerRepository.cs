using Domain.Interfaces;
using Domain.Models;

namespace DataAccess.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(LContext repositoryContext) : base(repositoryContext) { }
        public async Task<Customer?> GetByEP(string email, string password)
        {
            var result = await base.FindByCondition(ded => ded.Login == email && ded.Password == password);

            if (result == null || result.Count == 0) { return null; }

            return result[0];
        }
    }
}
