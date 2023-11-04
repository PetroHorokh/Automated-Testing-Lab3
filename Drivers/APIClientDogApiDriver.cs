namespace Lab3.Drivers;

public class ApiClientDogApiDriver
{
    readonly RestClient _client;
    private const string UrlCats = "https://dog.ceo/api";

    public ApiClientDogApiDriver()
    {
        var options = new RestClientOptions(UrlCats);
        _client = new RestClient(options);
    }

    public async Task<RestResponse> GetListOfAllBreeds()
    {
        var request = new RestRequest("breeds/list/all", Method.Get);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> GetRandomImage()
    {
        var request = new RestRequest("/breeds/image/random", Method.Get);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> GetImageByBreed(string breed)
    {
        var request = new RestRequest($"/breed/{breed}/images", Method.Get);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> GetListOfAllSubBreedsOfABreed(string breed)
    {
        var request = new RestRequest($"/breed/{breed}/list", Method.Get);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> GetBrowseBreedList(string subBreed)
    {
        var request = new RestRequest($"/breed/{subBreed}/images/random", Method.Get);
        return await _client.ExecuteAsync(request);
    }
}