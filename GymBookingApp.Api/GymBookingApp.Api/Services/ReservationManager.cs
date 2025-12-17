using GymBookingApp.Api.Models;

namespace GymBookingApp.Api.Services;

public class ReservationManager
{
    private readonly IPricingService _pricingService;

    public ReservationManager(IPricingService pricingService)
    {
        _pricingService = pricingService;
    }

    public Reservation CreateReservation(Member member, decimal basePrice, double occupancy)
    {
        var price = _pricingService.CalculatePrice(basePrice, member.Type, occupancy);

        return new Reservation
        {
            Member = member,
            BookingDate = DateTime.Now,
            FinalPrice = price
        };
    }
}