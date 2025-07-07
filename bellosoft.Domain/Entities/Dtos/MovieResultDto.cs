namespace bellosoft.Domain.Entities.Dtos
{
    public class MovieResultDto
    {
        public int Page { get; set; }
        public List<MovieItemDto> Results { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }
    }
}
