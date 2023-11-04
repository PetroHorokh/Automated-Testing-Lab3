Feature: Auth
	Auth token to use for access to the PUT and DELETE /booking

Scenario: Creates a new auth token
	Given user name - admin
	And password - passwordAdmin
	When send request to generate access token
	Then validate status code for auth
