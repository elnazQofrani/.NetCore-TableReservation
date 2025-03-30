using Domain.Entities;

namespace BusinessLayer.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreatAsync(Customer customer);
        Task<Customer> GetById(int Id);
          
    }
}
