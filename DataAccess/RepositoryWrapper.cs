using Domain.Interfaces;
using DataAccess.Repositories;

namespace DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        LContext _repContext;
        ICustomerRepository _customer;
        IGoodRepository _good;
        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                    _customer = new CustomerRepository(_repContext);
                return _customer;
            }
        }
        public IGoodRepository Good
        {
            get
            {
                if (_good == null)
                    _good= new GoodRepository(_repContext);
                return _good;
            }
        }
        public RepositoryWrapper(LContext repContext)
        {
            _repContext = repContext;
        }
        public async Task Save()
        {
            await _repContext.SaveChangesAsync();
        }
    }
}
