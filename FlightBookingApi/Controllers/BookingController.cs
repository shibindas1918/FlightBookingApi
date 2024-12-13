using FlightBookingApi.Interfaces;
using FlightBookingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
            
        }
        [HttpPost("create")]
        public IActionResult CreateBooking([FromBody] BookingRequestDto bookingDto)
        {
            var result = _bookingService.CreateBooking(bookingDto);
            return Ok(result);
        }

    }
}
