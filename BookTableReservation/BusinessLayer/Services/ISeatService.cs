using Domain.Entities;

namespace BusinessLayer.Services
{
    public interface ISeatService
    {
        Task<bool> IsSeatsAvailable(int id, DateTime desiredDateTime, TimeSpan desireStartTime);

        Task<List<Seat>> GetAvailableSeats(DateTime desiredDateTime, TimeSpan desireStartTime);


    }
}
