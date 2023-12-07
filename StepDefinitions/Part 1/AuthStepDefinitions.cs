using Gherkin;
using Lab3.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Lab3.StepDefinitions.Part_1;

[Binding]
public class AuthStepDefinitions
{
    private readonly User _user;
    readonly RestClient _client;
    private RestResponse? _restResponse;

    public AuthStepDefinitions(User user)
    {
        _user = user;
        _client = new RestClient("https://restful-booker.herokuapp.com/");
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

    [When("create and send request to generate access token")]
    public async Task WhenSendRequestToGenerateAccessToken()
    {
        var request = new RestRequest($"auth", Method.Post);
        request.RequestFormat = DataFormat.Json;
        request.AddJsonBody(_user);
        _restResponse = await _client.ExecuteAsync(request);
    }

    [Then("validate status code for auth")]
    public void WhenValidateStatusCode()
    {
        var code = (int)_restResponse.StatusCode;
        Assert.AreEqual(200, code);
    }
}