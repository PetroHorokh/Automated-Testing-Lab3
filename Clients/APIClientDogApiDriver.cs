namespace Lab3.Drivers;

public class ApiClientDogApiDriver
{
    readonly RestClient _client;
    private readonly string _urlCats = "https://dog.ceo/api";

    public ApiClientDogApiDriver()
    {
        var options = new RestClientOptions(_urlCats);
        _client = new RestClient(options);
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