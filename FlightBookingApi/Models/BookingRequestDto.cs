namespace FlightBookingApi.Models
{
    public class BookingRequestDto
    {
        public int UserId { get; set; }
        public int FlightId { get; set; }
        public int SeatCount { get; set; }
    }

}
