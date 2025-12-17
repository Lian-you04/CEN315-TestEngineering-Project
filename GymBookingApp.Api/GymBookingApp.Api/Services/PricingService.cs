namespace GymBookingApp.Api.Services;

using GymBookingApp.Api.Models;


public class PricingService : IPricingService
{
    public decimal CalculatePrice(decimal basePrice, MembershipType type, double occupancyRate)
    {
        
        decimal finalPrice = basePrice;

        if (type == MembershipType.Student) finalPrice *= 0.8m;
        else if (type == MembershipType.Premium) finalPrice *= 0.9m;

        if (occupancyRate > 0.8) finalPrice *= 1.15m;

        return finalPrice;
    }
}