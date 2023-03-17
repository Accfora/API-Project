using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _repositoryWrapper.Filter.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Filter model)
        {
            _repositoryWrapper.Filter.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Filter = await _repositoryWrapper.Filter
            .FindByCondition(x => x.FilterId == id);
            _repositoryWrapper.Filter.Delete(Filter.First());
            _repositoryWrapper.Save();
        }

    }
}
