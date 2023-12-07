namespace Lab3.StepDefinitions.Part_2;

[Binding]
public class DogApiStepDefinitions
{
    private string _breed = String.Empty;
    private RestResponse? _restResponse;
    readonly RestClient _client;

    public DogApiStepDefinitions()
    {
        _client = new RestClient("https://dog.ceo/api");
    }

    [Given(@"dog breed - (.*)")]
    public void GivenDogBreed(string breed)
    {
        _breed = breed;
    }

    [When(@"get all dog breeds")]
    public async Task WhenGetAllDogBreeds()
    {
        var request = new RestRequest("breeds/list/all", Method.Get);
        _restResponse = await _client.ExecuteAsync(request); ;
    }

    [When(@"get random image")]
    public async Task WhenGetRandomImage()
    {
        var request = new RestRequest("/breeds/image/random", Method.Get);
        _restResponse = await _client.ExecuteAsync(request);
    }

    [When(@"get images by breed")]
    public async Task WhenGetImagesByBreed()
    {
        var request = new RestRequest($"/breed/{_breed}/images", Method.Get);
        _restResponse = await _client.ExecuteAsync(request);
    }

    [When(@"get list of sub-breed")]
    public async Task WhenGetListOfSub_Breed()
    {
        var request = new RestRequest($"/breed/{_breed}/list", Method.Get);
        _restResponse = await _client.ExecuteAsync(request);
    }

    [When(@"get image of sub-breed")]
    public async Task WhenGetImageOfSub_Breed()
    {
        var request = new RestRequest($"/breed/{_breed}/images/random", Method.Get);
        _restResponse = await _client.ExecuteAsync(request);
    }


    [Then(@"validate status code")]
    public void ThenValidateStatusCode()
    {
        var code = (int)_restResponse.StatusCode;
        Assert.AreEqual(200, code);
    }
}