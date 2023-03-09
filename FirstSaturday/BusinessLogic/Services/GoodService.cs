using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class GoodService : IGoodService
    {
        IRepositoryWrapper _repositoryWrapper;
        public GoodService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<Good>> GetAll()
        {
            return _repositoryWrapper.Good.FindAll().ToListAsync();
        }
        public Task<Good> GetById(int id)
        {
            var user = _repositoryWrapper.Good
            .FindByCondition(x => x.GoodId == id).First();
            return Task.FromResult(user);
        }
        public Task Create(Good model)
        {
            _repositoryWrapper.Good.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Good model)
        {
            _repositoryWrapper.Good.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var user = _repositoryWrapper.Good
            .FindByCondition(x => x.GoodId == id).First();
            _repositoryWrapper.Good.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
    }
}
