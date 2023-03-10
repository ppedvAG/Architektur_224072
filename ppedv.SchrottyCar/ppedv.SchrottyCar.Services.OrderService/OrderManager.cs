using ppedv.SchrottyCar.Model.Contracts.Data;
using ppedv.SchrottyCar.Model.Contracts.Service;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Services.OrderService
{
    public class OrderManager : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerService _customerService;

        public OrderManager(IUnitOfWork unitOfWork, ICustomerService customerService)
        {
            _unitOfWork = unitOfWork;
            _customerService = customerService;
        }

        public void SaveNewOrder(Order order)
        {
            if (order.Customer == null)
                throw new ArgumentNullException("Custi is NULL");


            if (!_customerService.ValidateCustomer(order.Customer))
                throw new ArgumentNullException("Custi is doof");   


            _unitOfWork.OrderRepository.Add(order);
            _unitOfWork.SaveAll();
        }
    }
}