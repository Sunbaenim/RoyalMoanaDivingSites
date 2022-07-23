using System.ComponentModel.DataAnnotations;

namespace RoyalMoanaDivingSites.API.DTO.Image
{
    public class ImageAddDTO
    {
        [Required]
        public int DivingSiteId { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
        [Required]
        public bool IsMainImage { get; set; }
    }
}
