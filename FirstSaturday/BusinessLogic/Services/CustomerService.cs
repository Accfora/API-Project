using BusinessLogic.Interfaces;
using DataAccess.Models;
using DataAccess.Wrapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        IRepositoryWrapper _repositoryWrapper;
        public CustomerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public Task<List<Customer>> GetAll()
        {
            return _repositoryWrapper.Customer.FindAll().ToListAsync();
        }
        public Task<Customer> GetById(int id)
        {
            var user = _repositoryWrapper.Customer
            .FindByCondition(x => x.CustomerId == id).First();
            return Task.FromResult(user);
        }
        public Task Create(Customer model)
        {
            _repositoryWrapper.Customer.Create(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Update(Customer model)
        {
            _repositoryWrapper.Customer.Update(model);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            var user = _repositoryWrapper.Customer
            .FindByCondition(x => x.CustomerId == id).First();
            _repositoryWrapper.Customer.Delete(user);
            _repositoryWrapper.Save();
            return Task.CompletedTask;
        }

    }
}