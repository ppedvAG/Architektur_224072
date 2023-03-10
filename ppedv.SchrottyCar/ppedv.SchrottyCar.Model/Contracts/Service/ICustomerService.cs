using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Model.Contracts.Service
{
    public interface ICustomerService
    {
        public bool ValidateCustomer(Customer newCustomer);
    }
}
