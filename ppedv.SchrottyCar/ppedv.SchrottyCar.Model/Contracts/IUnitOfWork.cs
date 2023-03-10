using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Model.Contracts
{
    public interface IUnitOfWork
    {
        public ICarCommandRepository CarRepository { get; }
        public ICommandRepository<Order> OrderRepository { get; }
        public ICommandRepository<OrderItem> OrderItemRepository { get; }
        public ICommandRepository<Customer> CustomerRepository { get; }
        public ICommandRepository<Address> AddressRepository { get; }

        //public IRepository<T> GetRepo<T>() where T : Entity;

        void SaveAll();
    }
}
