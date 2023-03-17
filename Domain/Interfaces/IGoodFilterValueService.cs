using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IGoodFilterValueService
    {
        Task<List<GoodFilterValue>> GetAll();
        Task<GoodFilterValue> GetById(int id_g, int id_f);
        Task Create(GoodFilterValue model);
        Task Update(GoodFilterValue model);
        Task Delete(int id_g, int id_f);
    }
}
