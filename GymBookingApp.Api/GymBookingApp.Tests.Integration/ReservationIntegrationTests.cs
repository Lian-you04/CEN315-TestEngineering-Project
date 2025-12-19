using System.Net.Http.Json;
using GymBookingApp.Api.Controllers;
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
        var request = new ReservationRequest
        {
            Member = new Member { Id = 1, Name = "Dahir", Type = MembershipType.Student },
            BasePrice = 100m,
            Occupancy = 0.5
        };

        var response = await _client.PostAsJsonAsync("/api/reservations", request);
        response.EnsureSuccessStatusCode();

        var reservation = await response.Content.ReadFromJsonAsync<Reservation>();
        Assert.NotNull(reservation);
        Assert.Equal(80m, reservation.FinalPrice); 
    }

    [Fact]
    public async Task GetReservations_ShouldReturnOk()
    {
        var response = await _client.GetAsync("/api/reservations");
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }


    [Fact]
    public async Task CreateReservation_ShouldReturnBadRequest_WhenRequestIsNull()
    {
        
        var response = await _client.PostAsJsonAsync<ReservationRequest?>("/api/reservations", null);
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateReservation_ShouldReturnBadRequest_WhenMemberIsNull()
    {
        
        var requestWithNoMember = new ReservationRequest { Member = null, BasePrice = 100m };
        var response = await _client.PostAsJsonAsync("/api/reservations", requestWithNoMember);
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CreateReservation_ShouldReturnBadRequest_WhenPriceIsNegative()
    {
        
        var negativePriceRequest = new ReservationRequest
        {
            Member = new Member { Id = 1 },
            BasePrice = -50m
        };
        var response = await _client.PostAsJsonAsync("/api/reservations", negativePriceRequest);
        Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
    }
}