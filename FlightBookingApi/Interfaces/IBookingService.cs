using FlightBookingApi.Models;

namespace FlightBookingApi.Interfaces
{
    public interface IBookingService
    {
        BookingDto CreateBooking(BookingRequestDto bookingRequest);
        List<BookingDto> GetUserBookings(int userId);
    }

}
