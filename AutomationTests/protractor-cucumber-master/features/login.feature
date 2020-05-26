Feature: NLBC Login test
  As a user
  i want to test Login functionality of NLBC

  Background:
    Given I navigate to "http://www.google.com/"

  Scenario: Verify NLBC login with invalid credentials
    Then I should see the search page
    When I enter search keyword as "ho minh chung"
    And  I Click on search button
    Then I should see found results
    