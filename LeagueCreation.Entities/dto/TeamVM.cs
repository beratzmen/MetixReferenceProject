namespace LeagueCreation.Entities.dto
{
    public class TeamVM
    {
        //public int Id { get; set; }
        public int Team1Id { get; set; }
        public int Team2Id { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public short PointHome { get; set; } 
        public short PointAway { get; set; } 
    }
}
