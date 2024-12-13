using FlightBookingApi.Models;

namespace FlightBookingApi.Interfaces
{
    public interface IFlightService
    {
        List<FlightDto> SearchFlights(string origin, string destination, DateTime date);
        FlightDto GetFlightById(int flightId);
    }

}
