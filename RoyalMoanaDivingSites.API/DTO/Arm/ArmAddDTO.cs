using System.ComponentModel.DataAnnotations;

namespace RoyalMoanaDivingSites.API.DTO.Arm
{
    public class ArmAddDTO
    {
        [Required]
        public int DivingSiteId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
