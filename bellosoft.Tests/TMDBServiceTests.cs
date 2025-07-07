using bellosoft.Domain.Entities.Dtos;
using bellosoft.Domain.Settings;
using bellosoft.Service;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;

namespace bellosoft.Tests;

[TestClass]
public class TMDBServiceTests
{
    private Mock<HttpMessageHandler> _mockHttpMessageHandler;
    private HttpClient _httpClient;
    private Mock<IOptions<TMDBSettings>> _mockSettings;
    private TMDBService _service;

    [TestInitialize]
    public void Setup()
    {
        _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri("https://api.themoviedb.org/3/")
        };
        _mockSettings = new Mock<IOptions<TMDBSettings>>();

        var apiKey = Environment.GetEnvironmentVariable("TMDB:ApiKey") ?? "dummy-key-for-test";

        _mockSettings.Setup(x => x.Value).Returns(new TMDBSettings
        {
            ApiKey = apiKey,
            BaseUrl = "https://api.themoviedb.org/3/"
        });

        _service = new TMDBService(_httpClient, _mockSettings.Object);
    }

    [TestMethod]
    public async Task GetPopularMoviesAsync_Success_ReturnsMovieResult()
    {
        // Arrange
        var expectedResponse = new MovieResultDto
        {
            Page = 1,
            Results =
                [
                    new() { Id = 1, Title = "Test Movie", Overview = "Test Overview" }
                ],
            TotalPages = 1,
            TotalResults = 1
        };

        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(JsonSerializer.Serialize(expectedResponse))
        };

        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri.ToString().Contains("movie/popular")),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(response);

        // Act
        var result = await _service.GetPopularMoviesAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedResponse.Page, result.Page);
        Assert.AreEqual(1, result.Results.Count);
        Assert.AreEqual("Test Movie", result.Results[0].Title);
    }

    [TestMethod]
    public async Task GetPopularMoviesAsync_Error_ReturnsNull()
    {
        // Arrange
        var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

        _mockHttpMessageHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(response);

        // Act
        var result = await _service.GetPopularMoviesAsync();

        // Assert
        Assert.IsNull(result);
    }
}
