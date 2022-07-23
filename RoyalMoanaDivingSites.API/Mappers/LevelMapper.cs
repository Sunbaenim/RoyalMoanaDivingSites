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

        public static Level ToLevel(this LevelAddDTO dto)
        {
            return new Level
            {
                DivingSiteId = dto.DivingSiteId,
                LevelNumber = dto.LevelNumber
            };
        }
    }
}
