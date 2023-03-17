using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class GoodFilterValueService : IGoodFilterValueService
    {
        IRepositoryWrapper _repositoryWrapper;
        public GoodFilterValueService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<GoodFilterValue>> GetAll()
        {
            return await _repositoryWrapper.GoodFilterValue.FindAll();
        }
        public async Task<GoodFilterValue> GetById(int id_g, int id_f)
        {
            var GoodFilterValue = await _repositoryWrapper.GoodFilterValue
            .FindByCondition(x => x.FilterId == id_f && x.GoodId == id_g);
            return GoodFilterValue.First();
        }
        public async Task Create(GoodFilterValue model)
        {
            _repositoryWrapper.GoodFilterValue.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(GoodFilterValue model)
        {
            _repositoryWrapper.GoodFilterValue.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id_g, int id_f)
        {
            var GoodFilterValue = await _repositoryWrapper.GoodFilterValue
            .FindByCondition(x => x.FilterId == id_f && x.GoodId == id_g);
            _repositoryWrapper.GoodFilterValue.Delete(GoodFilterValue.First());
            _repositoryWrapper.Save();
        }

    }
}
