using GymBookingApp.Api.Models;
using GymBookingApp.Api.Services;
using Xunit;

namespace GymBookingApp.Tests.Unit;

public class PricingServiceTests
{
 
    [Fact]
    public void Student_Under_Normal_Occupancy_Should_Get_20_Percent_Discount()
    {
        
        var service = new PricingService();
        decimal basePrice = 100m;

       
        var result = service.CalculatePrice(basePrice, MembershipType.Student, 0.5);

        
        Assert.Equal(80m, result);
    }

    
    [Theory]
    [InlineData(100, MembershipType.Student, 0.5, 80)]   // Senaryo 1: Öğrenci, Normal Doluluk (%20 indirim)
    [InlineData(100, MembershipType.Student, 0.9, 92)]   // Senaryo 2: Öğrenci, Yüksek Doluluk (80 * 1.15 = 92)
    [InlineData(100, MembershipType.Premium, 0.5, 90)]   // Senaryo 3: Premium, Normal Doluluk (%10 indirim)
    [InlineData(100, MembershipType.Premium, 0.9, 103.5)] // Senaryo 4: Premium, Yüksek Doluluk (90 * 1.15 = 103.5)
    [InlineData(100, MembershipType.Standard, 0.5, 100)] // Senaryo 5: Standart, Normal Doluluk (İndirim yok)
    [InlineData(100, MembershipType.Standard, 0.9, 115)] // Senaryo 6: Standart, Yüksek Doluluk (%15 artış)
    public void Pricing_DecisionTable_Tests(decimal basePrice, MembershipType type, double occupancy, decimal expected)
    {
        
        var service = new PricingService();

       
        var result = service.CalculatePrice(basePrice, type, occupancy);

       
        Assert.Equal(expected, result);
    }
}