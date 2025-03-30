using Domain.Entities;

namespace BusinessLayer.Services
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerByIdAsync(int customerId);

        Task<Customer> CreatAsync(Customer customer);
    }
}
