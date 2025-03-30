
using BusinessLayer.Repositories;
using Domain.Data;
using Domain.Entities;
using System.Net.Http.Headers;

namespace BusinessLayer.Services
{
    public class SeatService : ISeatService
    {
        private readonly DbProjectContext dbContext;
        private SeatRespositoey _seatRepository;

        public SeatService(DbProjectContext dbContext)
        {
            this.dbContext = dbContext;
            _seatRepository = new SeatRespositoey(dbContext);


        }

        public Task<List<Seat>> GetAvailableSeats(DateTime desiredDateTime, TimeSpan desireStartTime)
        {
           return _seatRepository.GetAvailableSeats(desiredDateTime, desireStartTime);
        }

        public Task<bool> IsSeatsAvailable(int id, DateTime desiredDateTime, TimeSpan desireStartTime)
        {

            return _seatRepository.IsSeatsAvailable(id, desiredDateTime, desireStartTime);
        }
    }
}
