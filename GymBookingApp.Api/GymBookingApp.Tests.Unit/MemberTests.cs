using GymBookingApp.Api.Models;
using GymBookingApp.Api.Repositories;
using GymBookingApp.Api.Services;
using Moq; 
using Xunit;

namespace GymBookingApp.Tests.Unit;

public class MemberTests
{
    
    [Fact]
    public void Member_Properties_ShouldSetAndGetCorrectly()
    {
        var member = new Member { Id = 1, Name = "Dahir", Type = MembershipType.Student };
        Assert.Equal(1, member.Id);
        Assert.Equal("Dahir", member.Name);
        Assert.Equal(MembershipType.Student, member.Type);
    }

    [Fact]
    public void Reservation_Properties_ShouldSetAndGetCorrectly()
    {
        var member = new Member { Id = 1, Name = "Dahir", Type = MembershipType.Student };
        var reservation = new Reservation { Id = 101, Member = member, BasePrice = 100m, FinalPrice = 80m };
        Assert.Equal(101, reservation.Id);
        Assert.Equal(member, reservation.Member);
        Assert.Equal(100m, reservation.BasePrice);
        Assert.Equal(80m, reservation.FinalPrice);
    }


    [Fact]
    public async Task RemoveMember_ShouldReturnTrue_WhenMemberExists()
    {
        
        var memberId = 1;
        var mockRepo = new Mock<IMemberRepository>(); 

       
        mockRepo.Setup(r => r.GetByIdAsync(memberId))
                .ReturnsAsync(new Member { Id = memberId, Name = "Dahir" });

        var service = new MemberService(mockRepo.Object);

        
        var result = await service.RemoveMemberAsync(memberId);

        
        Assert.True(result); 
        mockRepo.Verify(r => r.DeleteMemberAsync(memberId), Times.Once);
    }

    [Fact]
    public async Task RemoveMember_ShouldReturnFalse_WhenMemberDoesNotExist()
    {
        
        var memberId = 99;
        var mockRepo = new Mock<IMemberRepository>();

        
        mockRepo.Setup(r => r.GetByIdAsync(memberId))
                .ReturnsAsync((Member?)null!);

        var service = new MemberService(mockRepo.Object);

     
        var result = await service.RemoveMemberAsync(memberId);

      
        Assert.False(result);
        mockRepo.Verify(r => r.DeleteMemberAsync(It.IsAny<int>()), Times.Never);
    }
}