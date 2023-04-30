using Domain.Interfaces;
using Domain.Models;

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
            await _repositoryWrapper.Order.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Order model)
        {
            await _repositoryWrapper.Order.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id_o, int id_c)
        {
            var Order = await _repositoryWrapper.Order
            .FindByCondition(x => x.OrderId == id_o && x.CustomerId == id_c);
            await _repositoryWrapper.Order.Delete(Order.First());
            await _repositoryWrapper.Save();
        }

    }
}
