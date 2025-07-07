using bellosoft.Domain.Entities.Dtos;
using bellosoft.Domain.Interfaces;
using bellosoft.Domain.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace bellosoft.Service
{
    public class TMDBService(HttpClient httpClient, IOptions<TMDBSettings> settings) : ITMDBService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _apiKey = settings.Value.ApiKey;

        public async Task<MovieResultDto?> GetPopularMoviesAsync(int page = 1, string language = "pt-BR")
        {
            var url = $"movie/popular?api_key={_apiKey}&language={language}&page={page}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            var result = await response.Content.ReadFromJsonAsync<MovieResultDto>();
            return result;
        }
    }
}
