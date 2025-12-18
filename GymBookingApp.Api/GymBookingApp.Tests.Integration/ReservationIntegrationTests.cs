using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using GymBookingApp.Api.Models; 
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
    public async Task CreateReservation_FromApi_ReturnsCorrectPrice()
    {
        
        var testRequest = new
        {
            Member = new { Id = 1, Name = "Dahir", Type = 2 }, // Student
            BasePrice = 100m,
            Occupancy = 0.9 // %10 zam eþiði
        };

       
        var response = await _client.PostAsJsonAsync("/api/reservations", testRequest);

        
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<Reservation>();

        // (100 * 0.8) * 1.1 = 88 TL olmalý
        Assert.Equal(88m, result.FinalPrice);
    }
}