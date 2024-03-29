﻿using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class CustomerService : ICustomerService
    {
        IRepositoryWrapper _repositoryWrapper;
        public CustomerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<Customer> Login(string email, string password)
        {
            var customer = await
                _repositoryWrapper.Customer.GetByEP(email, password);

            return customer;
        }
        public async Task<List<Customer>> GetAll()
        {
            return await _repositoryWrapper.Customer.FindAll();
        }
        public async Task<Customer> GetById(int id)
        {
            var customer = await _repositoryWrapper.Customer
            .FindByCondition(x => x.CustomerId == id);
            return customer.First();
        }
        public async Task Create(Customer model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (string.IsNullOrEmpty(model.Surname))
            {
                throw new ArgumentException(nameof(model.Surname));
            }

            if (string.IsNullOrEmpty(model.Name))
            {
                throw new ArgumentException(nameof(model.Name));
            }

            if (string.IsNullOrEmpty(model.Login))
            {
                throw new ArgumentException(nameof(model.Login));
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                throw new ArgumentException(nameof(model.Password));
            }

            await _repositoryWrapper.Customer.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Customer model)
        {
            await _repositoryWrapper.Customer.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var customer = await _repositoryWrapper.Customer
            .FindByCondition(x => x.CustomerId == id);
            await _repositoryWrapper.Customer.Delete(customer.First());
            await _repositoryWrapper.Save();
        }

    }
}