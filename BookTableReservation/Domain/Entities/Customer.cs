using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Customer
    {
        
        public int Id { get; set; }

    
        public string FirstName { get; set; }

        public string   LastName { get; set; }

        public string PhoneNumber { get; set; }

        [EmailAddress]        
        public string Email { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
