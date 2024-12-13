using FlightBookingApi.Interfaces;
using FlightBookingApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightBookingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
            
        }

        [HttpPost("add-flight")]
        public IActionResult AddFlight([FromBody] Flight flight)
        {
            _adminService.AddFlight(flight);
            return Ok("Flight added successfully");
        }

    }
}
