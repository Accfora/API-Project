using Domain.Models;

namespace Domain.Interfaces
{
    public interface IGoodService
    {
        Task<List<Good>> GetAll();
        Task<Good> GetById(int id);
        Task Create(Good model);
        Task Update(Good model);
        Task Delete(int id);
    }
}
