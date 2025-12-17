using GymBookingApp.Api.Models; 
using Xunit;

namespace GymBookingApp.Tests.Unit;

public class MemberTests
{
    [Fact]
    public void Member_Should_Store_Correct_Information()
    {

        var member = new Member
        {
            Id = 1,
            Name = "Deniz",
            Type = MembershipType.Student
        };

        Assert.Equal(1, member.Id);
        Assert.Equal("Deniz", member.Name);
        Assert.Equal(MembershipType.Student, member.Type);
    }
}