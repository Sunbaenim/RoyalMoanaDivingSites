using RoyalMoanaDivingSites.API.DTO.Arm;
using RoyalMoanaDivingSites.API.DTO.Enumerations;
using RoyalMoanaDivingSites.API.DTO.Image;
using RoyalMoanaDivingSites.API.DTO.Level;
using RoyalMoanaDivingSites.API.DTO.Validations;
using System.ComponentModel.DataAnnotations;

namespace RoyalMoanaDivingSites.API.DTO.DivingSite
{
    public class DivingSiteAddDTO
    {
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        public List<ImageAddDTO> Images { get; set; }
        [Required]
        [Range(-99.999999999999999, 99.999999999999999)]
        public decimal Latitude { get; set; }
        [Required]
        [Range(-99.999999999999999, 99.999999999999999)]
        public decimal Longitude { get; set; }
        [Required]
        public List<ArmAddDTO> Arms { get; set; }
        [Required]
        public List<LevelAddDTO> Levels { get; set; }
        [MaxLength(7)]
        public string? Tide { get; set; }
        [MaxLength(20)]
        public string Current { get; set; }
        [Required]
        public short Depth { get; set; }
        [Required]
        [DifficultyValidation(typeof(Difficulty))]
        public string LaunchingDifficulty { get; set; }
        public string? LaunchingDistance { get; set; }
        [MaxLength(2)]
        [DifficultyValidation(typeof(CardinalPoints))]
        public string? WindDirection { get; set; }
        [Required]
        public bool IsSnorkeling { get; set; }
        [Required]
        public bool IsInitiation { get; set; }
        [Required]
        public bool IsForDisabledPerson { get; set; }
        [Required]
        public bool IsSpecialDiving { get; set; }
    }
}
