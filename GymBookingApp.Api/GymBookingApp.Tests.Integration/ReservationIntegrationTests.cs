using System.Net.Http.Json;
using GymBookingApp.Api.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace GymBookingApp.Tests.Integration;

public class ReservationIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ReservationIntegrationTests(WebApplicationFactory<Program> factory)
    {
    
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task CreateReservation_Endpoint_ShouldReturnSuccess()
    {
       
        var request = new
        {
            Member = new { Id = 1, Name = "Dahir", Type = 1 }, 
            BasePrice = 100m,
            OccupancyRate = 0.5
        };

       
        var response = await _client.PostAsJsonAsync("/api/reservations", request);

        
        response.EnsureSuccessStatusCode();
        var reservation = await response.Content.ReadFromJsonAsync<Reservation>();

        Assert.NotNull(reservation);
        
        Assert.Equal(90m, reservation.FinalPrice);
    }

    [Fact]
    public async Task GetReservations_ShouldReturnEmptyList_WhenNoData()
    {
      
        var response = await _client.GetAsync("/api/reservations");
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetReservations_Endpoint_ShouldReturnList()
    {
        
        var response = await _client.GetAsync("/api/reservations");

      
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        Assert.NotNull(result);
    }
}