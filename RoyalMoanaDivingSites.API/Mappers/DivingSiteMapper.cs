using RoyalMoanaDivingSites.API.DTO.DivingSite;
using RoyalMoanaDivingSites.DAL.Entities;

namespace RoyalMoanaDivingSites.API.Mappers
{
    static class DivingSiteMapper
    {
        public static DivingSiteIndexDTO ToDivingSiteIndexDTO(this DivingSite entity)
        {
            return new DivingSiteIndexDTO()
            {
                ID = entity.ID,
                Name = entity.Name,
                Image = entity.Images.Where(i => i.IsMainImage)
                    .Select(i => i.ToImageIndexDTO()).FirstOrDefault()!.ImageUrl,
                MapsUrl = "https://maps.google.com/?q=" + entity.Latitude + "," + entity.Longitude,
                Arm = entity.Arms.Select(a => a.ToArmIndexDTO()).ToList(),
                Level = entity.Level,
                Tide = entity.Tide!,
                Current = entity.Current,
                Depth = entity.Depth

            };
        }
    }
}
