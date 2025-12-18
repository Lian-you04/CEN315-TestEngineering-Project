using GymBookingApp.Api.Models;
using GymBookingApp.Api.Services;
using FsCheck;
using FsCheck.Xunit;
using Xunit;

namespace GymBookingApp.Tests.Unit;

public class PricingServiceTests
{
    private readonly PricingService _pricingService;

    public PricingServiceTests()
    {
        _pricingService = new PricingService();
    }

    // 5.5 Decision Tables (Karar Tablosu)
    [Theory]
    [InlineData(100, MembershipType.Standard, 0.5, 100)]
    [InlineData(100, MembershipType.Student, 0.5, 80)]
    [InlineData(100, MembershipType.Premium, 0.5, 90)]
    [InlineData(100, MembershipType.Standard, 0.9, 110)] // Beklenen: 110 (100 * 1.1)
    [InlineData(100, MembershipType.Student, 0.9, 88)]   // Beklenen: 88 (80 * 1.1)
    public void CalculatePrice_ShouldApplyRulesCorrectly(decimal basePrice, MembershipType type, double occupancy, decimal expected)
    {
        
        var result = _pricingService.CalculatePrice(basePrice, type, occupancy);

        
        Assert.Equal(expected, result);
    }

    [Property]
    public bool Price_Should_Never_Be_Negative(double basePriceRaw, int membershipTypeRaw, double occupancyRaw)
    {
        // ARRANGE: Sayısal olmayan verileri filtrele
        if (double.IsNaN(basePriceRaw) || double.IsInfinity(basePriceRaw)) return true;
        if (double.IsNaN(occupancyRaw) || double.IsInfinity(occupancyRaw)) return true;


        decimal basePrice = (decimal)(Math.Clamp(Math.Abs(basePriceRaw), 0, 1000000));
        MembershipType type = (MembershipType)(Math.Abs(membershipTypeRaw) % 3); // 0,1,2
        double occupancy = Math.Abs(occupancyRaw) % 1.1;

        var result = _pricingService.CalculatePrice(basePrice, type, occupancy);

        // ASSERT: Fiyat hiçbir zaman negatif olamaz
        return result >= 0;
    }
}