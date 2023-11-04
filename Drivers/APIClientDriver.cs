using Lab3.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace Lab3.Drivers;

public class ApiClientDriver
{
    readonly RestClient _client;
    private const string UrlTest = "https://restful-booker.herokuapp.com/";
    private const string UrlCats = "https://cat-fact.herokuapp.com";

    public ApiClientDriver()
    {
        var options = new RestClientOptions(UrlTest);
        _client = new RestClient(options);
    }

    public async Task<RestResponse> CreateBookingRequest(BookingReq payload)
    {
        var request = new RestRequest("booking", Method.Post);
        request.AddHeader("Accept", "application/json");
        request.RequestFormat = DataFormat.Json;
        request.AddJsonBody(payload);
        var result = await _client.ExecuteAsync(request);
        return result;
    }

    public async Task<RestResponse> GetBookingIdsRequest()
    {
        var request = new RestRequest("booking", Method.Get);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> GetBookingByIdRequest(int id)
    {
        var request = new RestRequest("booking", Method.Get);
        request.AddParameter("id", id.ToString(), ParameterType.UrlSegment);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> DeleteBookingByIdRequest(int id)
    {
        var request = new RestRequest($"booking/{id}", Method.Delete);
        request.AddParameter("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=", ParameterType.HttpHeader);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> UpdateBookingRequest(BookingReq payload, int id)
    {
        var request = new RestRequest($"booking/{id}", Method.Put);
        request.AddHeader("Accept", "application/json");
        request.AddParameter("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=", ParameterType.HttpHeader);
        request.RequestFormat = DataFormat.Json;
        request.AddJsonBody(payload);
        var result = await _client.ExecuteAsync(request);
        return result;
    }

    public async Task<RestResponse> PatchBookingRequest(BookingReq payload, int id)
    {
        var request = new RestRequest($"booking/{id}", Method.Patch);
        request.AddHeader("Accept", "application/json");
        request.AddParameter("Authorization", "Basic YWRtaW46cGFzc3dvcmQxMjM=", ParameterType.HttpHeader);
        request.RequestFormat = DataFormat.Json;
        request.AddJsonBody(payload);
        var result = await _client.ExecuteAsync(request);
        return result;
    }

    public async Task<RestResponse> GetHealthCheck()
    {
        var request = new RestRequest("ping", Method.Get);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> PostCreateToken(User payload)
    {
        var request = new RestRequest($"auth", Method.Post);
        request.RequestFormat = DataFormat.Json;
        request.AddJsonBody(payload);
        var result = await _client.ExecuteAsync(request);
        return result;
    }
}