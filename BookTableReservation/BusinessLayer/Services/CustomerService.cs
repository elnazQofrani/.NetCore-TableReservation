using Domain.Data;
using Domain.Entities;
using BusinessLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly DbProjectContext dbContext;
        private CustomerRepository _customerRepository;

        public CustomerService(DbProjectContext dbContext)
        {

            this.dbContext = dbContext;
            _customerRepository = new CustomerRepository(dbContext);
        }

        public Task<Customer> CreatAsync(Customer customer)
        {
            return _customerRepository.CreatAsync(customer);
        }

        public async Task<Customer> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetById(customerId);
            return customer;

        }
    }
}
