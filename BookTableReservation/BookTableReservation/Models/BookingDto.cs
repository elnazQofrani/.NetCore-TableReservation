using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookTableReservation.Models
{
    public class BookingDto
    {

        public int CustomerId { get; set; }

        [Required(ErrorMessage ="StudentId Needed.")]
        public int SeatId { get; set; }

        [Required]
        public DateTime BookingDateTime { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

    }
}
