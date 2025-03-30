using Domain.Entities;
using BusinessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Data;

namespace BusinessLayer.Services
{
    public class BookingService : IBookingService
    {
        private readonly DbProjectContext dbContext;
        private BookingRepository _bookingRepository;

        public BookingService(DbProjectContext dbContext)
        {
            this.dbContext = dbContext;
            _bookingRepository = new BookingRepository(dbContext);
        }


        public async Task<Booking> CreatAsync(Booking booking)
        {
            return await _bookingRepository.CreatAsync(booking);
        }

        public async Task<Booking?> GetById(int Id)
        {
            return await _bookingRepository.GetById(Id);

        }

        public async Task Update(Booking booking)
        {
            await _bookingRepository.Update(booking);
        }
    }
}
