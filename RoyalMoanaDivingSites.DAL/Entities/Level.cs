namespace RoyalMoanaDivingSites.DAL.Entities
{
    public class Level
    {
        public int ID { get; set; }
        public int DivingSiteId { get; set; }
        public DivingSite DivingSite { get; set; }
        public int LevelNumber { get; set; }
    }
}
