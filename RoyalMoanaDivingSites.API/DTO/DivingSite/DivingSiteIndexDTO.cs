using RoyalMoanaDivingSites.API.DTO.Arm;
using RoyalMoanaDivingSites.API.DTO.Image;

namespace RoyalMoanaDivingSites.API.DTO.DivingSite
{
    public class DivingSiteIndexDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string MapsUrl { get; set; }
        public List<ArmIndexDTO> Arm { get; set; }
        public string Level { get; set; }
        public string Tide { get; set; }
        public string Current { get; set; }
        public short Depth { get; set; }
    }
}
