using FlightBookingApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            
            _flightService = flightService;
        }
        [HttpGet("search")]
        public IActionResult SearchFlights(string origin, string destination, DateTime date)
        {
            var flights = _flightService.SearchFlights(origin, destination, date);
            return Ok(flights);
        }

    }
}
