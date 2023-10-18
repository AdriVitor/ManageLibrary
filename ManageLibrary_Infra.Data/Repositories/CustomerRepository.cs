using ManageLibrary_Domain.Entities;
using ManageLibrary_Infra.Context;
using ManageLibrary_Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManageLibrary_Infra.Repositories {
    public class CustomerRepository : ICustomerRepository {
        private readonly AppDbContext _appDbContext;
        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddCustomer(Customer customer) {
            await _appDbContext.Customer.AddAsync(customer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomer(int id) {
            var customer = await GetCustomerById(id);

            _appDbContext.Customer.Remove(customer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerById(int id) {
            var customer = await _appDbContext.Customer.FirstOrDefaultAsync(c=>c.Id == id);
             if(customer == null) {
                throw new Exception("Não foi encontrado nenhum cliente com esse Id");
            }

            return customer;
        }

        public async Task UpdateCustomer(Customer customer) {
            _appDbContext.Customer.Update(customer);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
