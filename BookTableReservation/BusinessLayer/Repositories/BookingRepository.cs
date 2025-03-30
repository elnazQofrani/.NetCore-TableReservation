using Domain.Data;
using Domain.Entities;
using System.Diagnostics.CodeAnalysis;

namespace BusinessLayer.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DbProjectContext dbContext;


        public BookingRepository(DbProjectContext dbContext)
        {

            this.dbContext = dbContext;
        }

        public async Task<Booking> CreatAsync(Booking booking)
        {
           await dbContext.Booking.AddAsync(booking);
            await dbContext.SaveChangesAsync();
            return booking;

        }

        public async Task<Booking?> GetById(int Id)
        {
           return await dbContext.Booking.FindAsync(Id);
           
        }

        public async Task Update(Booking booking)
        {
            await dbContext.SaveChangesAsync();
        }


    }
}
