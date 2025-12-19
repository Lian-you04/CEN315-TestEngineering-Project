using System.Net;
using System.Net.Http.Json;
using GymBookingApp.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GymBookingApp.Tests.IntegrationTests;

public class MembersIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public MembersIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

   
    [Fact]
    public async Task Post_Member_AddsNewMember_AndReturnsCreated()
    {
        var newMember = new Member { Id = 10, Name = "Test User", Type = MembershipType.Student };
        var response = await _client.PostAsJsonAsync("/api/members", newMember);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        var savedMember = await response.Content.ReadFromJsonAsync<Member>();
        Assert.Equal("Test User", savedMember?.Name);
    }

    [Fact]
    public async Task CreateMember_ReturnsBadRequest_WhenMemberIsNull()
    {
        
        var response = await _client.PostAsJsonAsync<Member?>("/api/members", null);
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    
    [Fact]
    public async Task GetMemberById_ReturnsOk_WhenMemberExists()
    {
        
        var response = await _client.GetAsync("/api/members/1");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetMemberById_ReturnsNotFound_WhenMemberDoesNotExist()
    {
        var response = await _client.GetAsync("/api/members/999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

   
    [Fact]
    public async Task Delete_Member_RemovesMember_AndReturnsNoContent()
    {
       
        var memberToDelete = new Member { Id = 20, Name = "To Be Deleted", Type = MembershipType.Standard };
        await _client.PostAsJsonAsync("/api/members", memberToDelete);

        var response = await _client.DeleteAsync("/api/members/20");
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }

    [Fact]
    public async Task Delete_NonExistentMember_ReturnsNotFound()
    {
        var response = await _client.DeleteAsync("/api/members/888");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}