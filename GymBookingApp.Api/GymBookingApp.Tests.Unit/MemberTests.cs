using GymBookingApp.Api.Models;
using Xunit;

namespace GymBookingApp.Tests.Unit;

public class MemberTests
{
    [Fact]
    public void Member_Properties_ShouldSetAndGetCorrectly()
    {
        
        var member = new Member
        {
            Id = 1,
            Name = "Dahir",
            Type = MembershipType.Student
        };

        Assert.Equal(1, member.Id);
        Assert.Equal("Dahir", member.Name);
        Assert.Equal(MembershipType.Student, member.Type);
    }

    [Fact]
    public void Reservation_Properties_ShouldSetAndGetCorrectly()
    {
        
        var member = new Member { Id = 1, Name = "Dahir", Type = MembershipType.Student };
        var reservation = new Reservation
        {
            Id = 101,
            Member = member,
            BasePrice = 100m,
            FinalPrice = 80m
        };

        Assert.Equal(101, reservation.Id);
        Assert.Equal(member, reservation.Member);
        Assert.Equal(100m, reservation.BasePrice);
        Assert.Equal(80m, reservation.FinalPrice);
    }
}