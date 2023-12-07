Feature: Booking
	Automated tests for booking API

@noauth
@getbookingbyid
Scenario: Get booking by id
	Given booking id 67
	When create request
	And send request
	Then validate returned status code(200)

@noauth
@getbookingids
Scenario: Get all booking ids
	When create request
	And send request
	Then validate returned status code(200)

@noauth
@createbooking
Scenario: Create new booking with valid inputs
	Given user with first name "Pete"
	And last name "Horokh"
	And total price 111
	And deposit paid true
	And booking dates: checking - 2018-01-01, checkout - 2018-01-02
	And additional needs: breakfast, dinner
	When create request
	And send request
	Then validate returned status code(200)

@auth
@updatebooking
Scenario: Update existing booking by id with valid inputs
	Given booking id 14
	And user with first name "Pete"
	And last name "Horokh"
	And total price 111
	And deposit paid true
	And booking dates: checking - 2018-01-01, checkout - 2018-01-02
	And additional needs: breakfast, dinner
	When create request
	And send request
	Then validate returned status code(200)

@auth
@patchbooking
Scenario: Patch existing booking by id
	Given booking id 10
	And user with first name "Petro"
	When create request
	And send request
	Then validate returned status code(200)

@auth
@deletebooking
Scenario: Delete booking by id
	Given booking id 200
	When create request
	And send request
	Then validate returned status code(201)