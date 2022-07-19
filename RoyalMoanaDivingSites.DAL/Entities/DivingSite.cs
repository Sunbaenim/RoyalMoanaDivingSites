using RoyalMoanaDivingSites.DAL.Enumerations;

namespace RoyalMoanaDivingSites.DAL.Entities
{
    public class DivingSite
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Image> Images { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<Arm> Arms { get; set; }
        public List<Level> Levels { get; set; }
        public string? Tide { get; set; }
        public string Current { get; set; }
        public short Depth { get; set; }
        public Difficulty LaunchingDifficulty { get; set; }
        public string? LaunchingDistance { get; set; }
        public CardinalPoints? WindDirection { get; set; }
        public bool IsSnorkeling { get; set; }
        public bool IsInitiation { get; set; }
        public bool IsForDisabledPerson { get; set; }
        public bool IsSpecialDiving { get; set; }
    }
}
