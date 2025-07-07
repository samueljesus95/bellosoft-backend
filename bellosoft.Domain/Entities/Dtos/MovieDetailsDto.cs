namespace bellosoft.Domain.Entities.Dtos
{
    public class MovieDetailsDto
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public long Budget { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public int Id { get; set; }
        public string ImdbId { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<ProductionCountry> ProductionCountries { get; set; }
        public string ReleaseDate { get; set; }
        public long Revenue { get; set; }
        public int Runtime { get; set; }
        public List<SpokenLanguage> SpokenLanguages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
    }
}
