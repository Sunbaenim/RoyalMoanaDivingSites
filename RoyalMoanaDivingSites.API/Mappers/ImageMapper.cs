using RoyalMoanaDivingSites.API.DTO.Image;
using RoyalMoanaDivingSites.DAL.Entities;

namespace RoyalMoanaDivingSites.API.Mappers
{
    static class ImageMapper
    {
        public static ImageIndexDTO ToImageIndexDTO(this Image entity)
        {
            return new ImageIndexDTO
            {
                ID = entity.ID,
                DivingSiteId = entity.DivingSiteId,
                ImageUrl = entity.ImageUrl
            };
        }
    }
}
