using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _repositoryWrapper.Manufacturer.Create(model);
            _repositoryWrapper.Save();
        }
        public async Task Update(Manufacturer model)
        {
            _repositoryWrapper.Manufacturer.Update(model);
            _repositoryWrapper.Save();
        }
        public async Task Delete(int id)
        {
            var Manufacturer = await _repositoryWrapper.Manufacturer
            .FindByCondition(x => x.ManufacturerId == id);
            _repositoryWrapper.Manufacturer.Delete(Manufacturer.First());
            _repositoryWrapper.Save();
        }

    }
}
