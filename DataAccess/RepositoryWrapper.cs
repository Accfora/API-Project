using Domain.Interfaces;
using DataAccess.Repositories;

namespace DataAccess
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        LContext _repContext;
        ICustomerRepository _customer;
        IGoodRepository _good;
        IOrderRepository _order;
        IOrderContentRepository _orderContent;
        IManufacturerRepository _manufacturer;
        ICategoryRepository _category;
        IFilterRepository _filter;
        IGoodFilterValueRepository _goodFilterValue;
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
                    _good = new GoodRepository(_repContext);
                return _good;
            }
        }
        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                    _order = new OrderRepository(_repContext);
                return _order;
            }
        }
        public IOrderContentRepository OrderContent
        {
            get
            {
                if (_orderContent == null)
                    _orderContent = new OrderContentRepository(_repContext);
                return _orderContent;
            }
        }
        public IManufacturerRepository Manufacturer
        {
            get
            {
                if (_manufacturer == null)
                    _manufacturer = new ManufacturerRepository(_repContext);
                return _manufacturer;
            }
        }
        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                    _category = new CategoryRepository(_repContext);
                return _category;
            }
        }
        public IFilterRepository Filter
        {
            get
            {
                if (_filter == null)
                    _filter = new FilterRepository(_repContext);
                return _filter;
            }
        }
        public IGoodFilterValueRepository GoodFilterValue
        {
            get
            {
                if (_goodFilterValue == null)
                    _goodFilterValue = new GoodFilterValueRepository(_repContext);
                return _goodFilterValue;
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
