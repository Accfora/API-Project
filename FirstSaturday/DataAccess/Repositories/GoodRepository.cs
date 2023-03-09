using DataAccess.Interfaces;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public class GoodRepository : RepositoryBase<Good>, IGoodRepository
    {
        public GoodRepository(LContext repositoryContext) : base(repositoryContext) { }
    }
}
