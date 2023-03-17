using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IOrderContentService
    {
        Task<List<OrderContent>> GetAll();
        Task<OrderContent> GetById(int id_o, int id_c, int ig_g);
        Task Create(OrderContent model);
        Task Update(OrderContent model);
        Task Delete(int id_o, int id_c, int ig_g);
    }
}
