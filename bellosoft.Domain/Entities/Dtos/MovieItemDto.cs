namespace bellosoft.Domain.Entities.Dtos
{
    public class MovieItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public string PosterPath { get; set; }
        public double VoteAverage { get; set; }
    }
}
