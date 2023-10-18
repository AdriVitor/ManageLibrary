using ManageLibrary_Application.DTOs;
using ManageLibrary_Domain.Entities;

namespace ManageLibrary_Application.Interfaces
{
    public interface ICustomerService {
        public Task<ReadCustomerDTO> GetCustomerById(int id);
        public Task AddCustomer(CustomerDTO customerDTO);
        public Task UpdateCustomer(CustomerDTO customerDTO);
        public Task DeleteCustomer(int id);
    }
}
