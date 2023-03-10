using ppedv.SchrottyCar.Model.Contracts.Data;
using ppedv.SchrottyCar.Model.Contracts.Service;
using ppedv.SchrottyCar.Model.DomainModel;

namespace ppedv.SchrottyCar.Services.CustomerServices
{
    public class CustomerManager : ICustomerService
    {
        
        public CustomerManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public bool ValidateCustomer(Customer newCustomer)
        {
            if (newCustomer == null) 
                throw new ArgumentNullException("Null ist doof");


            return true;
        }
    }
}