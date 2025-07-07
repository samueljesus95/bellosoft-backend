namespace bellosoft.Domain.Entities.Dtos
{
    public class NBAStandingDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Conference { get; set; }
    }
}
