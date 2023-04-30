using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        IRepositoryWrapper _repositoryWrapper;
        public CategoryService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _repositoryWrapper.Category.FindAll();
        }
        public async Task<Category> GetById(int id)
        {
            var Category = await _repositoryWrapper.Category
            .FindByCondition(x => x.CategotyId == id);
            return Category.First();
        }
        public async Task Create(Category model)
        {
            await _repositoryWrapper.Category.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Category model)
        {
            await _repositoryWrapper.Category.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Category = await _repositoryWrapper.Category
            .FindByCondition(x => x.CategotyId == id);
            await _repositoryWrapper.Category.Delete(Category.First());
            await _repositoryWrapper.Save();
        }

    }
}






