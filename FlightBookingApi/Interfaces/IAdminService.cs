using FlightBookingApi.Models;

namespace FlightBookingApi.Interfaces
{
    public interface IAdminService
    {
        void AddFlight(Flight flight);
        void UpdateFlight(Flight flight);
        void DeleteFlight(int flightId);
    }

}
