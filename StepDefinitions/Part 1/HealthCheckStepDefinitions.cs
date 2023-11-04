using Lab3.Drivers;

namespace Lab3.StepDefinitions;

[Binding]
public class HealthCheckStepDefinitions
{
    private RestResponse? _restResponse;
    private HttpStatusCode _statusCode;
    private readonly ApiClientDriver _api;

    public HealthCheckStepDefinitions(ApiClientDriver api)
    {
        _api = api;
    }

    [When("send request to get health check")]
    public async Task SendRequestToGetHealthCheck()
    {
        _restResponse = await _api.GetHealthCheck();
    }

    [Then("validate returned status code for health check")]
    public void ThenValidateStatusCode()
    {
        _statusCode = _restResponse.StatusCode;

        var code = (int)_statusCode;
        Assert.AreEqual(201, code);
    }
}