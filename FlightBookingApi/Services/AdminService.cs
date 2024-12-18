using Dapper;
using FlightBookingApi.Interfaces;
using FlightBookingApi.Models;
using System.Data;

namespace FlightBookingApi.Services
{
    public class AdminService : IAdminService
{
    private readonly IDbConnection _dbConnection;

    public AdminService(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }
// Method to create add a flight details 
    public void AddFlight(Flight flight)
    {
        var query = @"
            INSERT INTO Flights (Airline, Origin, Destination, DepartureTime, ArrivalTime, TotalSeats, AvailableSeats, Price)
            VALUES (@Airline, @Origin, @Destination, @DepartureTime, @ArrivalTime, @TotalSeats, @AvailableSeats, @Price)";

        _dbConnection.Execute(query, flight);
    }
//Method to update a particular flight details 
    public void UpdateFlight(Flight flight)
    {
        var query = @"
            UPDATE Flights
            SET Airline = @Airline, Origin = @Origin, Destination = @Destination,
                DepartureTime = @DepartureTime, ArrivalTime = @ArrivalTime, 
                TotalSeats = @TotalSeats, AvailableSeats = @AvailableSeats, Price = @Price
            WHERE FlightId = @FlightId";

        _dbConnection.Execute(query, flight);
    }
//Method to delete a particular flight details 
    public void DeleteFlight(int flightId)
    {
        var query = "DELETE FROM Flights WHERE FlightId = @FlightId";
        _dbConnection.Execute(query, new { FlightId = flightId });
    }
}

}
