using Dapper;
using FlightBookingApi.Models;
using System.Data;

namespace FlightBookingApi.Services
{
    public class FlightService : IFlightService
    {
        private readonly IDbConnection _dbConnection;

        public FlightService(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<FlightDto> SearchFlights(string origin, string destination, DateTime date)
        {
            var query = @"
            SELECT FlightId, Airline, Origin, Destination, DepartureTime, ArrivalTime, AvailableSeats, Price
            FROM Flights
            WHERE Origin = @Origin AND Destination = @Destination AND CAST(DepartureTime AS DATE) = @Date";

            var flights = _dbConnection.Query<FlightDto>(query, new { Origin = origin, Destination = destination, Date = date }).ToList();
            return flights;
        }

        public FlightDto GetFlightById(int flightId)
        {
            var query = @"
            SELECT FlightId, Airline, Origin, Destination, DepartureTime, ArrivalTime, AvailableSeats, Price
            FROM Flights
            WHERE FlightId = @FlightId";

            var flight = _dbConnection.QueryFirstOrDefault<FlightDto>(query, new { FlightId = flightId });
            return flight;
        }
    }

}
