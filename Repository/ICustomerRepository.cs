

using CarConnect.Model;

namespace CarConnect.Repository
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomerById();
        public List<Customer> GetCustomerByUsername(string username);

        public int RegisterCustomer(Customer customer);

        public int UpdateCustomer(Customer customer);
        public int UpdateCustomerAuto(Customer customer);


        public int DeleteCustomer(int customerId);
    }
}
