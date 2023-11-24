using Lab3.Drivers;
using Lab3.Models;
using Lab3.Models.BookingRequest;

namespace Lab3.StepDefinitions;

[Binding]
public class BookingStepDefinitions
{
    private int _id;
    private RestRequest _request;
    private RestResponse? _restResponse;
    private BookingReq _bookingReq;
    readonly RestClient _client;
    readonly ScenarioContext _scenarioContext;

    public BookingStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new RestClient("https://restful-booker.herokuapp.com/");
    }

    [Given("booking id (.*)")]
    public void GivenBookingId(int id)
    {
        _id = id;
    }

    [Given(@"user with first name (.*)")]
    public void GivenFirstName(string name)
    {
        _bookingReq = new BookingReq();
        _bookingReq.firstname = name;
    }

    [Given(@"last name (.*)")]
    public void GivenLastName(string lastname)
    {
        
        _bookingReq.lastname = lastname;
    }

    [Given(@"total price (.*)")]
    public void GivenTotalPrice(int totalPrice)
    {
        _bookingReq.totalprice = totalPrice;
    }

    [Given(@"deposit paid (.*)")]
    public void GivenDepositPaid(bool depositPaid)
    {
        _bookingReq.depositpaid = depositPaid;
    }

    [Given(@"booking dates: checking - (.*), checkout - (.*)")]
    public void GivenBookingDates(string checking, string checkout)
    {
        _bookingReq.bookingdates = new BookingDates(checking, checkout);
    }

    [Given(@"additional needs: (.*)")]
    public void GivenAdditionalNeeds(string additionalNeeds)
    {
        _bookingReq.additionalneeds = additionalNeeds;
    }

    [When(@"create request")]
    public void WhenCreateRequest()
    {
        var tags = _scenarioContext.ScenarioInfo.Tags;
        var headers = new Dictionary<string, string>();
        var resource = String.Empty;
        var method = Method.Get;
        var id = 0;

        switch (tags[0])
        {
            case "noauth":
                headers.Add("Accept", "application/json");

                break;
            case "auth":
                headers.Add("Accept", "application/json");
                headers.Add("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=");

                break;
        }

        switch (tags[1])
        {
            case "getbookingids":
                resource = "booking";
                method = Method.Get;

                break;
            case "getbookingbyid":
                resource = $"booking/{_id}";
                method = Method.Get;

                break;
            case "createbooking":
                resource = $"booking";
                method = Method.Post;

                break;
            case "updatebooking":
                resource = $"booking/{_id}";
                method = Method.Put;

                break;
            case "patchbooking":
                resource = $"booking/{_id}";
                method = Method.Patch;

                break;
            case "deletebooking":
                resource = $"booking/{_id}";
                method = Method.Delete;

                break;
        }

        var request = new Request
        {
            resource = resource,
            id = id,
            headers = headers,
            body = new List<object>{_bookingReq},
            method = method
        };

        _request = CreateRequest(request);
    }

    [When(@"send request")]
    public async Task WhenSendRequest()
    {
        _restResponse = await SendRequest(_request);
    }

    [Then(@"validate returned status code\(200\)")]
    public void ThenValidateStatusCode200()
    {
        var code = (int)_restResponse.StatusCode;
        Assert.AreEqual(200, code);
    }

    [Then(@"validate returned status code\(201\)")]
    public void ThenValidateStatusCode201()
    {
        var code = (int)_restResponse.StatusCode;
        Assert.AreEqual(201, code);
    }

    private RestRequest CreateRequest(Request requestInfo)
    {
        var request = new RestRequest(requestInfo.resource, requestInfo.method);
        if (requestInfo.headers != null)
            foreach (var header in requestInfo.headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

        request.RequestFormat = DataFormat.Json;

        foreach (var bodyElement in requestInfo.body!)
        {
            if(bodyElement != null) request.AddJsonBody(bodyElement);
        }

        return request;
    }

    private async Task<RestResponse> SendRequest(RestRequest request)
    {
        var result = await _client.ExecuteAsync(request);
        return result;
    }
}