using bellosoft.Domain.Entities;
using bellosoft.Domain.Entities.Dtos;
using bellosoft.Domain.Entities.Errors;
using bellosoft.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace bellosoft.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MoviesController(ITMDBService tmdbService) : ControllerBase
    {
        private readonly ITMDBService _tmdbService = tmdbService;

        [HttpGet("popular")]
        [ProducesResponseType(typeof(ApiResponse<MovieResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Search popular movies")]
        public async Task<IActionResult> GetPopularMovies([FromQuery] int page = 1)
        {
            var result = await _tmdbService.GetPopularMoviesAsync(page);
            return Ok(new ApiResponse<MovieResultDto>(200, "Popular movies obtained successfully", result));
        }

        [HttpGet("search")]
        [ProducesResponseType(typeof(ApiResponse<MovieResultDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Search movie by name")]
        public async Task<IActionResult> SearchMovies([FromQuery] string query, [FromQuery] int page = 1)
        {
            if (string.IsNullOrWhiteSpace(query)) throw new BadRequestException("The 'query' parameter is required");

            var result = await _tmdbService.SearchMoviesAsync(query, page);
            return Ok(new ApiResponse<MovieResultDto>(200, "Search completed successfully", result));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ApiResponse<MovieDetailsDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerOperation(Summary = "Get movie detail by id")]
        public async Task<IActionResult> GetMovieDetails(int id)
        {
            var movie = await _tmdbService.GetMovieDetailsAsync(id);
            return Ok(new ApiResponse<MovieDetailsDto>(200, "Movie details", movie));
        }
    }
}
