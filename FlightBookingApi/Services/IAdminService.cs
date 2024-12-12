using FlightBookingApi.Models;

namespace FlightBookingApi.Services
{
    public interface IAdminService
    {
        void AddFlight(Flight flight);
        void UpdateFlight(Flight flight);
        void DeleteFlight(int flightId);
    }

}
