﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Seat
    {
     
        public int Id { get; set; }

   
        public int SeatNumber { get; set; }
     
        public ICollection<Booking> Bookings { get; set; }

    }
}
