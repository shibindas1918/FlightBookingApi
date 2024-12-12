using FlightBookingApi.Models;

namespace FlightBookingApi.Services
{
    public interface IBookingService
    {
        BookingDto CreateBooking(BookingRequestDto bookingRequest);
        List<BookingDto> GetUserBookings(int userId);
    }

}
