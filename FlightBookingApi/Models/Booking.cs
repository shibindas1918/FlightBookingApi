using Microsoft.AspNetCore.Http.HttpResults;

namespace FlightBookingApi.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int UserId { get; set; }
        public int FlightId { get; set; }
        public DateTime BookingDate { get; set; }
        public int SeatCount { get; set; }
        public decimal TotalAmount { get; set; }
    }

}
