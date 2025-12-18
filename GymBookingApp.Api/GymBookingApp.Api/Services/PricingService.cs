namespace GymBookingApp.Api.Services;

using GymBookingApp.Api.Models;

public class PricingService : IPricingService
{
    public decimal CalculatePrice(decimal basePrice, MembershipType type, double occupancy)
    {
        decimal price = basePrice;

        // 1. Üyelik İndirimleri
        if (type == MembershipType.Student) price *= 0.8m;     // %20 indirim
        else if (type == MembershipType.Premium) price *= 0.9m; // %10 indirim

        
        if (occupancy >= 0.8)
        {
            price *= 1.1m;
        }

        return Math.Round(price, 2);
    }
}