using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class OrderContentService : IOrderContentService
    {
        IRepositoryWrapper _repositoryWrapper;
        public OrderContentService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<OrderContent>> GetAll()
        {
            return await _repositoryWrapper.OrderContent.FindAll();
        }
        public async Task<OrderContent> GetById(int id_o, int id_c, int id_g)
        {
            var OrderContent = await _repositoryWrapper.OrderContent
            .FindByCondition(x => x.OrderId == id_o && x.CustomerId == id_c && x.GoodId == id_g);
            return OrderContent.First();
        }
        public async Task Create(OrderContent model)
        {
            await _repositoryWrapper.OrderContent.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(OrderContent model)
        {
            await _repositoryWrapper.OrderContent.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id_o, int id_c, int id_g)
        {
            var OrderContent = await _repositoryWrapper.OrderContent
            .FindByCondition(x => x.OrderId == id_o && x.CustomerId == id_c && x.GoodId == id_g);
            await _repositoryWrapper.OrderContent.Delete(OrderContent.First());
            await _repositoryWrapper.Save();
        }

    }
}
