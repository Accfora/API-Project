using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFilterService
    {
        Task<List<Filter>> GetAll();
        Task<Filter> GetById(int id);
        Task Create(Filter model);
        Task Update(Filter model);
        Task Delete(int id);
    }
}
