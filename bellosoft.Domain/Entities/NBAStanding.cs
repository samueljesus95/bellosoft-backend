namespace bellosoft.Domain.Entities
{
    public class NBAStanding
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Rank { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string Conference { get; set; }
        public int Season { get; set; }
    }
}
