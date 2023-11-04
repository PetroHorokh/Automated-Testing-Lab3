using Lab3.Drivers;
using Lab3.Models;

namespace Lab3.StepDefinitions;

[Binding]
public class AuthStepDefinitions
{
    private readonly ApiClientDriver _api;
    private RestResponse _restResponse;
    private HttpStatusCode _statusCode;
    private readonly User _user;

    public AuthStepDefinitions(ApiClientDriver api, User user)
    {
        _api = api;
        _user = user;
    }

    [Given("user name - (.*)")]
    public void GivenUserName(string username)
    {
        _user.username = username;
    }

    [Given("password - (.*)")]
    public void GivenUserPassword(string password)
    {
        _user.password = password;
    }

    [When("send request to generate access token")]
    public async Task WhenSendRequestToGenerateAccessToken()
    {
        _restResponse = await _api.PostCreateToken(_user);
    }

    [Then("validate status code for auth")]
    public void WhenValidateStatusCode()
    {
        _statusCode = _restResponse.StatusCode;

        var code = (int)_statusCode;
        Assert.AreEqual(200, code);
    }
}