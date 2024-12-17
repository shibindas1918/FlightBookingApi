using Dapper;
using FlightBookingApi.Interfaces;
using FlightBookingApi.Models;
using System.Data;

namespace FlightBookingApi.Services
{
    public class BookingService : IBookingService
    {
        private readonly IDbConnection _dbConnection;

        public BookingService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public BookingDto CreateBooking(BookingRequestDto bookingRequest)
        {
            // Check seat availability
            var flightQuery = "SELECT AvailableSeats, Price FROM Flights WHERE FlightId = @FlightId";
            var flight = _dbConnection.QueryFirstOrDefault<FlightDto>(flightQuery, new { bookingRequest.FlightId });

            if (flight == null || flight.AvailableSeats < bookingRequest.SeatCount)
                throw new Exception("Insufficient seats available");

            // Update available seats in the flight 
            var updateSeatsQuery = "UPDATE Flights SET AvailableSeats = AvailableSeats - @SeatCount WHERE FlightId = @FlightId";
            _dbConnection.Execute(updateSeatsQuery, new { bookingRequest.SeatCount, bookingRequest.FlightId });

            // Insert booking seats 
            var bookingQuery = @"
            INSERT INTO Bookings (UserId, FlightId, SeatCount, TotalAmount)
            OUTPUT INSERTED.BookingId
            VALUES (@UserId, @FlightId, @SeatCount, @TotalAmount)";

            var totalAmount = flight.Price * bookingRequest.SeatCount;
            var bookingId = _dbConnection.ExecuteScalar<int>(bookingQuery, new
            {
                bookingRequest.UserId,
                bookingRequest.FlightId,
                bookingRequest.SeatCount,
                TotalAmount = totalAmount
            });
            //Building the BookingDTO
            return new BookingDto
            {
                BookingId = bookingId,
                UserId = bookingRequest.UserId,
                FlightId = bookingRequest.FlightId,
                SeatCount = bookingRequest.SeatCount,
                TotalAmount = totalAmount
            };
        }
        
        //Reterving User Bookings 

        public List<BookingDto> GetUserBookings(int userId)
        {
            var query = @"
            SELECT BookingId, UserId, FlightId, SeatCount, TotalAmount, BookingDate
            FROM Bookings
            WHERE UserId = @UserId";

            var bookings = _dbConnection.Query<BookingDto>(query, new { UserId = userId }).ToList();
            return bookings;
        }
    }

}
