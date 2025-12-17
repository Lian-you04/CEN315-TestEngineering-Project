using GymBookingApp.Api.Models;
using GymBookingApp.Api.Services;
using Moq; 
using Xunit;

namespace GymBookingApp.Tests.Unit;

public class ReservationManagerTests
{
    [Fact]
    public void CreateReservation_Should_Use_Price_From_PricingService()
    {

        var mockPricingService = new Mock<IPricingService>();

        mockPricingService
            .Setup(x => x.CalculatePrice(It.IsAny<decimal>(), It.IsAny<MembershipType>(), It.IsAny<double>()))
            .Returns(75.0m);


        var manager = new ReservationManager(mockPricingService.Object);
        var member = new Member { Name = "Ali", Type = MembershipType.Standard };


        var result = manager.CreateReservation(member, 100m, 0.5);


        Assert.Equal(75.0m, result.FinalPrice);

        mockPricingService.Verify(x => x.CalculatePrice(It.IsAny<decimal>(), It.IsAny<MembershipType>(), It.IsAny<double>()), Times.Once);
    }
}