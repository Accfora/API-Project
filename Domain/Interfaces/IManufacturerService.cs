using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IManufacturerService
    {
        Task<List<Manufacturer>> GetAll();
        Task<Manufacturer> GetById(int id);
        Task Create(Manufacturer model);
        Task Update(Manufacturer model);
        Task Delete(int id);
    }
}
