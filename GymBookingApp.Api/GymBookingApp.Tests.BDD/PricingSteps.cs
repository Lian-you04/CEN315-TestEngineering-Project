using GymBookingApp.Api.Models;
using GymBookingApp.Api.Services;
using TechTalk.SpecFlow;
using Xunit;

namespace GymBookingApp.Tests.BDD;

[Binding] 
public class PricingSteps
{
    private decimal _basePrice;
    private MembershipType _type;
    private double _occupancy;
    private decimal _finalPrice;
    private readonly PricingService _pricingService = new();

    [Given(@"the base price is (.*)")]
    public void GivenTheBasePriceIs(decimal basePrice)
    {
        _basePrice = basePrice;
    }

    [Given(@"the member type is '(.*)'")]
    public void GivenTheMemberTypeIs(string type)
    {
        
        _type = Enum.Parse<MembershipType>(type);
    }

    [Given(@"the gym occupancy is (.*)")]
    public void GivenTheGymOccupancyIs(double occupancy)
    {
        _occupancy = occupancy;
    }

    [When(@"the price is calculated")]
    public void WhenThePriceIsCalculated()
    {
        _finalPrice = _pricingService.CalculatePrice(_basePrice, _type, _occupancy);
    }

    [Then(@"the final price should be (.*)")]
    public void ThenTheFinalPriceShouldBe(decimal expectedPrice)
    {
      
        Assert.Equal(expectedPrice, _finalPrice);
    }
}