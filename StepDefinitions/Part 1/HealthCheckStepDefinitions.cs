namespace Lab3.StepDefinitions.Part_1;

[Binding]
public class HealthCheckStepDefinitions
{
    private RestResponse? _restResponse;
    readonly RestClient _client;

    public HealthCheckStepDefinitions()
    {
        _client = new RestClient("https://restful-booker.herokuapp.com/");
    }

    [When("create and send request for health check")]
    public async Task SendRequestToGetHealthCheck()
    {
        var request = new RestRequest("ping", Method.Get);
        _restResponse = await _client.ExecuteAsync(request);
    }

    [Then("validate returned status code for health check")]
    public void ThenValidateStatusCode()
    {
        var code = (int)_restResponse.StatusCode;
        Assert.AreEqual(201, code);
    }
}