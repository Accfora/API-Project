using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class ManufacturerService : IManufacturerService
    {
        IRepositoryWrapper _repositoryWrapper;
        public ManufacturerService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
        public async Task<List<Manufacturer>> GetAll()
        {
            return await _repositoryWrapper.Manufacturer.FindAll();
        }
        public async Task<Manufacturer> GetById(int id)
        {
            var Manufacturer = await _repositoryWrapper.Manufacturer
            .FindByCondition(x => x.ManufacturerId == id);
            return Manufacturer.First();
        }
        public async Task Create(Manufacturer model)
        {
            await _repositoryWrapper.Manufacturer.Create(model);
            await _repositoryWrapper.Save();
        }
        public async Task Update(Manufacturer model)
        {
            await _repositoryWrapper.Manufacturer.Update(model);
            await _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Manufacturer = await _repositoryWrapper.Manufacturer
            .FindByCondition(x => x.ManufacturerId == id);
            await _repositoryWrapper.Manufacturer.Delete(Manufacturer.First());
            await _repositoryWrapper.Save();
        }

    }
}
