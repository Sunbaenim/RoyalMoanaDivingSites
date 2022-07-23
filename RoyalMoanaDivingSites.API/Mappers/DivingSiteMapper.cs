using RoyalMoanaDivingSites.API.DTO.DivingSite;
using RoyalMoanaDivingSites.API.DTO.Image;
using RoyalMoanaDivingSites.DAL.Entities;
using RoyalMoanaDivingSites.DAL.Enumerations;

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
                Arms = entity.Arms.Select(a => a.ToArmIndexDTO()).ToList(),
                Levels = entity.Levels.Select(l => l.ToLevelIndexDTO()).ToList(),
                Tide = entity.Tide!,
                Current = entity.Current,
                Depth = entity.Depth
            };
        }

        public static DivingSiteDetailDTO ToDivingSiteDetailDTO(this DivingSite entity)
        {
            return new DivingSiteDetailDTO
            {
                ID = entity.ID,
                Name = entity.Name,
                Images = entity.Images.Select(i => i.ToImageIndexDTO()).ToList(),
                MapsUrl = "https://maps.google.com/?q=" + entity.Latitude + "," + entity.Longitude,
                Arms = entity.Arms.Select(a => a.ToArmIndexDTO()).ToList(),
                Levels = entity.Levels.Select(l => l.ToLevelIndexDTO()).ToList(),
                Tide = entity.Tide!,
                Current = entity.Current,
                Depth = entity.Depth,
                LaunchingDifficulty = entity.LaunchingDifficulty.ToString(),
                LaunchingDistance = entity.LaunchingDistance!,
                WindDirection = entity.WindDirection.ToString()!,
                IsSnorkeling = entity.IsSnorkeling,
                IsInitiation = entity.IsInitiation,
                IsForDisabledPerson = entity.IsForDisabledPerson,
                IsSpecialDiving = entity.IsSpecialDiving
            };
        }

        public static DivingSite ToDivingSite(this DivingSiteAddDTO dto, List<ImageAddDTO> images)
        {
            return new DivingSite
            {
                Name = dto.Name,
                Images = images.Select(i => i.ToImage()).ToList(),
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Arms = dto.Arms.Select(a => a.ToArm()).ToList(),
                Levels = dto.Levels.Select(l => l.ToLevel()).ToList(),
                Tide = dto.Tide,
                Current = dto.Current,
                Depth = dto.Depth,
                LaunchingDifficulty = Enum.Parse<Difficulty>(dto.LaunchingDifficulty),
                LaunchingDistance = dto.LaunchingDistance,
                WindDirection = !string.IsNullOrEmpty(dto.WindDirection) ? Enum.Parse<CardinalPoints>(dto.WindDirection!) : null,
                IsSnorkeling = dto.IsSnorkeling,
                IsInitiation = dto.IsInitiation,
                IsForDisabledPerson = dto.IsForDisabledPerson,
                IsSpecialDiving = dto.IsSpecialDiving

            };
        }
    }
}
