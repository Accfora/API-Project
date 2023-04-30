using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class FilterService : IFilterService
    {
        IRepositoryWrapper _repositoryWrapper;
        public FilterService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Filter>> GetAll()
        {
            return await _repositoryWrapper.Filter.FindAll();
        }
        public async Task<Filter> GetById(int id)
        {
            var Filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.FilterId == id);
            return Filter.First();
        }
        public async Task Create(Filter model)
        {
            await _repositoryWrapper.Filter.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Filter model)
        {
            await _repositoryWrapper.Filter.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.FilterId == id);
            await _repositoryWrapper.Filter.Delete(Filter.First());
            await _repositoryWrapper.Save();
        }

    }
}
