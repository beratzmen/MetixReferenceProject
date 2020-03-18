namespace LeagueCreation.Entities.dto
{
    public class FixtureVM
    {
        public int Id { get; set; }
        public string Home { get; set; }
        public int HomeId { get; set; }
        public string Away { get; set; }
        public int AwayId { get; set; }
        public int Week { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int PointHome { get; set; }
        public int PointAway { get; set; }
        public bool ScoreCheck { get; set; }
    }
}
