using ppedv.SchrottyCar.Model.Contracts.Data;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Data.EfCore
{
    public class EfUnitOfWork : IUnitOfWork
    {
        SchrottyContext _context;
        private readonly string _conString;

        public EfUnitOfWork(string conString)
        {
            _context = new SchrottyContext(conString);
            _conString = conString;
        }

        public ICarRepository CarRepository => new EfCarRepository(_context);

        public IRepository<Order> OrderRepository => new EfRepository<Order>(_context);

        public IRepository<OrderItem> OrderItemRepository => new EfRepository<OrderItem>(_context);

        public IRepository<Customer> CustomerRepository => new EfRepository<Customer>(_context);

        public IRepository<Address> AddressRepository => new EfRepository<Address>(_context);

        public void SaveAll()
        {
            _context.SaveChanges();
            _context = new SchrottyContext(_conString); //reset LazyLoading cache
        }
    }
}
