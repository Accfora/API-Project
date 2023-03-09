using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
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
        public void Save()
        {
            _repContext.SaveChanges();
        }
    }
}
