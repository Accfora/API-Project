using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        IRepositoryWrapper _repositoryWrapper;
        public OrderService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Order>> GetAll()
        {
            return await _repositoryWrapper.Order.FindAll();
        }
        public async Task<Order> GetById(int id_o, int id_c)
        {
            var Order = await _repositoryWrapper.Order
            .FindByCondition(x => x.OrderId == id_o && x.CustomerId == id_c);
            return Order.First();
        }
        public async Task Create(Order model)
        {
            _repositoryWrapper.Order.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Order model)
        {
            _repositoryWrapper.Order.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id_o, int id_c)
        {
            var Order = await _repositoryWrapper.Order
            .FindByCondition(x => x.OrderId == id_o && x.CustomerId == id_c);
            _repositoryWrapper.Order.Delete(Order.First());
            _repositoryWrapper.Save();
        }

    }
}
