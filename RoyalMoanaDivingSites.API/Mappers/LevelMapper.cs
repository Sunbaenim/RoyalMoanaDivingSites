using RoyalMoanaDivingSites.DAL.Entities;
using RoyalMoanaDivingSites.API.DTO.Level;

namespace RoyalMoanaDivingSites.API.Mappers
{
    static class LevelMapper
    {
        public static LevelIndexDTO ToLevelIndexDTO(this Level entity)
        {
            return new LevelIndexDTO
            {
                ID = entity.ID,
                DivingSiteId = entity.DivingSiteId,
                LevelNumber = entity.LevelNumber
            };
        }
    }
}
