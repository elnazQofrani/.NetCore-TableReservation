using Domain.Entities;

namespace BusinessLayer.Repositories
{
    public interface IBookingRepository
    {
        Task<Booking> CreatAsync(Booking booking);
        Task<Booking?> GetById(int Id);
        Task Update(Booking booking);


    }
}
