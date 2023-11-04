Feature: Booking
	Automated tests for booking API

Scenario: Get booking by id
	Given booking id 67
	When send request to get booking by id
	Then validate returned status code(200)

Scenario: Create new booking with valid inputs
	Given user with first name "Pete"
	And last name "Horokh"
	And total price 111
	And deposit paid true
	And booking dates: checking - 2018-01-01, checkout - 2018-01-02
	And additional needs: breakfast, dinner
	When send request to create booking
	Then validate returned status code(200)

Scenario: Get all booking ids
	When send request to get booking ids
	Then validate returned status code(200)

Scenario: Update existing booking by id with valid inputs
	Given booking id 5
	And user with first name "Pete"
	And last name "Horokh"
	And total price 111
	And deposit paid true
	And booking dates: checking - 2018-01-01, checkout - 2018-01-02
	And additional needs: breakfast, dinner
	When send request to update booking
	Then validate returned status code(200)

Scenario: Patch existing booking by id
	Given booking id 7
	And user with first name "Petro"
	When send request to patch booking
	Then validate returned status code(200)

Scenario: Delete booking by id
	Given booking id 344
	When send request to delete booking by id
	Then validate returned status code(201)