Feature: Gym Pricing Calculation

  @pricing
  Scenario: Calculate student price with high occupancy
    Given the base price is 100
    And the member type is 'Student'
    And the gym occupancy is 0.9
    When the price is calculated
    Then the final price should be 88