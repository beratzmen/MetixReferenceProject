namespace LeagueCreation.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Fixture")]
    public partial class Fixture
    {
        public int Id { get; set; }
        [Required]
        //[StringLength(50)]
        public int Home { get; set; }
        [Required]
        //[StringLength(50)]
        public int Away { get; set; }
        public short Week { get; set; }
        public short HomeScore { get; set; }
        public short AwayScore { get; set; }
    }
}
