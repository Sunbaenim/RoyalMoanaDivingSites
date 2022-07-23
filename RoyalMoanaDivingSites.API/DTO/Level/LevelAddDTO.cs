using System.ComponentModel.DataAnnotations;

namespace RoyalMoanaDivingSites.API.DTO.Level
{
    public class LevelAddDTO
    {
        [Required]
        public int DivingSiteId { get; set; }
        [Required]
        public int LevelNumber { get; set; }
    }
}
