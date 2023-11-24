Feature: HealthCheck
	Health check endpoint to confirm whether the API is up and running
Scenario: Health check
	When create and send request for health check
	Then validate returned status code for health check
