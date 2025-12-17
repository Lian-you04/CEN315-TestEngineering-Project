using Microsoft.AspNetCore.Mvc;
using GymBookingApp.Api.Models;
using GymBookingApp.Api.Services;

namespace GymBookingApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly ReservationManager _manager;

    public ReservationsController(IPricingService pricingService)
    {
     
        _manager = new ReservationManager(pricingService);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ReservationRequest request)
    {
        
        if (request == null || request.Member == null)
        {
            return BadRequest("Geçersiz rezervasyon verisi.");
        }

       
        var reservation = _manager.CreateReservation(
            request.Member,
            request.BasePrice,
            request.Occupancy
        );

        return Ok(reservation);
    }
}


public class ReservationRequest
{
    public Member Member { get; set; } = new();
    public decimal BasePrice { get; set; }
    public double Occupancy { get; set; }
}