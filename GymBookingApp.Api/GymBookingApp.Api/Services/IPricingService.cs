namespace GymBookingApp.Api.Services;

using GymBookingApp.Api.Models;

public interface IPricingService
{
    decimal CalculatePrice(decimal basePrice, MembershipType type, double occupancyRate);
}