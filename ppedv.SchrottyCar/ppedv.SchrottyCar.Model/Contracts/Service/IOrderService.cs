using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Model.Contracts.Service
{
    public interface IOrderService
    {
        public void SaveNewOrder(Order order);
    }
}
