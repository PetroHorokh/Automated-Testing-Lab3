using Lab3.Drivers;

namespace Lab3.StepDefinitions.Part_2;

[Binding]
public class DogApiStepDefinitions
{
    private string? _breed = String.Empty;

    private RestResponse? _restResponse;
    private HttpStatusCode _statusCode;
    private readonly ApiClientDogApiDriver _api;

    public DogApiStepDefinitions(ApiClientDogApiDriver api)
    {
        _api = api;
    }

    [Given(@"dog breed - (.*)")]
    public void GivenDogBreed(string breed)
    {
        _breed = breed;
    }

    [When(@"get all dog breeds")]
    public async Task WhenGetAllDogBreeds()
    {
        _restResponse = await _api.GetListOfAllBreeds();
    }

    [When(@"get random image")]
    public async Task WhenGetRandomImage()
    {
        _restResponse = await _api.GetRandomImage();
    }

    [When(@"get images by breed")]
    public async Task WhenGetImagesByBreed()
    {
        _restResponse = await _api.GetImageByBreed(_breed);
    }

    [When(@"get list of sub-breed")]
    public async Task WhenGetListOfSub_Breed()
    {
        _restResponse = await _api.GetListOfAllSubBreedsOfABreed(_breed);
    }

    [When(@"get image of sub-breed")]
    public async Task WhenGetImageOfSub_Breed()
    {
        _restResponse = await _api.GetBrowseBreedList(_breed);
    }


    [Then(@"validate status code")]
    public void ThenValidateStatusCode()
    {
        _statusCode = _restResponse.StatusCode;

        var code = (int)_statusCode;
        Assert.AreEqual(200, code);
    }
}