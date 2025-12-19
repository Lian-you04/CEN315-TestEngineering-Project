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
        
        if (request == null)
        {
            return BadRequest("İstek boş olamaz.");
        }

        if (request.Member == null)
        {
            return BadRequest("Üye bilgisi eksik.");
        }

        if (request.BasePrice < 0)
        {
            return BadRequest("Fiyat negatif olamaz.");
        }

        
        var reservation = _manager.CreateReservation(
            request.Member,
            request.BasePrice,
            request.Occupancy
        );

        return Ok(reservation);
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new List<Reservation>());
    }
}

public class ReservationRequest
{
  
    public Member? Member { get; set; }
    public decimal BasePrice { get; set; }
    public double Occupancy { get; set; }
}