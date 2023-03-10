using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Model.Contracts
{
    public interface IUnitOfWork
    {
        public ICarRepository CarRepository { get; }
        public IRepository<Order> OrderRepository { get; }
        public IRepository<OrderItem> OrderItemRepository { get; }
        public IRepository<Customer> CustomerRepository { get; }
        public IRepository<Address> AddressRepository { get; }

        //public IRepository<T> GetRepo<T>() where T : Entity;

        void SaveAll();
    }
}
