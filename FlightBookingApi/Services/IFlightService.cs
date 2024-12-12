using FlightBookingApi.Models;

namespace FlightBookingApi.Services
{
    public interface IFlightService
    {
        List<FlightDto> SearchFlights(string origin, string destination, DateTime date);
        FlightDto GetFlightById(int flightId);
    }

}
