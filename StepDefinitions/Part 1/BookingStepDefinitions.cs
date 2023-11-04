using Lab3.Drivers;
using Lab3.Models;
using System.Xml.Linq;

namespace Lab3.StepDefinitions;

[Binding]
public class BookingStepDefinitions
{
    private int _id;
    private RestResponse? _restResponse;
    private HttpStatusCode _statusCode;
    private readonly ApiClientDriver _api;
    private readonly BookingReq _bookingReq;

    public BookingStepDefinitions(BookingReq bookingReq,  ApiClientDriver api)
    {
        _bookingReq = bookingReq;
        _api = api;
    }

    [Given("booking id (.*)")]
    public void GivenBookingId(int id)
    {
        _id = id;
    }

    [Given(@"user with first name (.*)")]
    public void GivenFirstName(string name)
    {
        
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

    [When("send request to get booking by id")]
    public async Task WhenSendRequestToGetBookingById()
    {
        _restResponse = await _api.GetBookingByIdRequest(_id);
    }

    [When(@"send request to get booking ids")]
    public async Task WhenSendRequestToGetBookingIds()
    {
        _restResponse = await _api.GetBookingIdsRequest(); ;
    }

    [When(@"send request to delete booking by id")]
    public async Task WhenSendRequestToDeleteBookingById()
    {
        _restResponse = await _api.DeleteBookingByIdRequest(_id);
    }

    [When(@"send request to create booking")]
    public async Task WhenSendRequestToCreateBooking()
    {
        _restResponse = await _api.CreateBookingRequest(_bookingReq);
    }

    [When(@"send request to update booking")]
    public async Task WhenSendRequestToUpdateBooking()
    {
        _restResponse = await _api.UpdateBookingRequest(_bookingReq, _id);
    }

    [When(@"send request to patch booking")]
    public async Task WhenSendRequestToPatchBooking()
    {
        _restResponse = await _api.PatchBookingRequest(_bookingReq, _id);
    }

    [Then(@"validate returned status code\(200\)")]
    public void ThenValidateStatusCode200()
    {
        _statusCode = _restResponse.StatusCode;

        var code = (int)_statusCode;
        Assert.AreEqual(200, code);
    }

    [Then(@"validate returned status code\(201\)")]
    public void ThenValidateStatusCode201()
    {
        _statusCode = _restResponse.StatusCode;

        var code = (int)_statusCode;
        Assert.AreEqual(201, code);
    }
}