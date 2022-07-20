using RoyalMoanaDivingSites.API.DTO.Arm;
using RoyalMoanaDivingSites.API.DTO.Image;
using RoyalMoanaDivingSites.API.DTO.Level;

namespace RoyalMoanaDivingSites.API.DTO.DivingSite
{
    public class DivingSiteDetailDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<ImageIndexDTO> Images { get; set; }
        public string MapsUrl { get; set; }
        public List<ArmIndexDTO> Arms { get; set; }
        public List<LevelIndexDTO> Levels { get; set; }
        public string? Tide { get; set; }
        public string Current { get; set; }
        public short Depth { get; set; }
        public string LaunchingDifficulty { get; set; }
        public string? LaunchingDistance { get; set; }
        public string? WindDirection { get; set; }
        public bool IsSnorkeling { get; set; }
        public bool IsInitiation { get; set; }
        public bool IsForDisabledPerson { get; set; }
        public bool IsSpecialDiving { get; set; }
    }
}
