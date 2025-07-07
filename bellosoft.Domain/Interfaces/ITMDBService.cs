using bellosoft.Domain.Entities.Dtos;

namespace bellosoft.Domain.Interfaces
{
    public interface ITMDBService
    {
        Task<MovieResultDto?> GetPopularMoviesAsync(int page = 1, string language = "pt-BR");
        Task<MovieResultDto?> SearchMoviesAsync(string query, int page = 1, string language = "pt-BR");
        Task<MovieDetailsDto?> GetMovieDetailsAsync(int movieId, string language = "pt-BR");
    }
}
