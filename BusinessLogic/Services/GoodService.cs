﻿using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class GoodService : IGoodService
    {
        IRepositoryWrapper _repositoryWrapper;
        public GoodService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Good>> GetAll()
        {
            return await _repositoryWrapper.Good.FindAll();
        }
        public async Task<Good> GetById(int id)
        {
            var good = await _repositoryWrapper.Good.FindByCondition(x => x.GoodId == id);
            return good.First();
        }
        public async Task Create(Good model)
        {
            await _repositoryWrapper.Good.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Good model)
        {
            await _repositoryWrapper.Good.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var customer = await _repositoryWrapper.Good
            .FindByCondition(x => x.GoodId == id);
            await _repositoryWrapper.Good.Delete(customer.First());
            await _repositoryWrapper.Save();
        }
    }
}
