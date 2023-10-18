using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Infra.Interfaces {
    public interface ICustomerRepository {
        public Task<Customer> GetCustomerById(int id);
        public Task AddCustomer(Customer customer);
        public Task UpdateCustomer(Customer customer);
        public Task DeleteCustomer(int id);
    }
}
