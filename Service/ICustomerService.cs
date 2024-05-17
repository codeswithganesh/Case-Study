

namespace CarConnect.Service
{
    internal interface ICustomerService
    {
        public void GetCustomerById();
        public void GetCustomerByUsername();
        public void RegisterCustomer();
        public void UpdateCustomer();

        public void DeleteCustomer();
        
    }
}
