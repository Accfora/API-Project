using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class GoodFilterValueRepository : RepositoryBase<GoodFilterValue>, IGoodFilterValueRepository
    {
        public GoodFilterValueRepository(LContext repositoryContext) : base(repositoryContext) { }
    }
}
