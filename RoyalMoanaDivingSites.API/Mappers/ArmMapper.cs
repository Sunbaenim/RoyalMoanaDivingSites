using RoyalMoanaDivingSites.API.DTO.Arm;
using RoyalMoanaDivingSites.DAL.Entities;

namespace RoyalMoanaDivingSites.API.Mappers
{
    static class ArmMapper
    {
        public static ArmIndexDTO ToArmIndexDTO(this Arm entity)
        {
            return new ArmIndexDTO
            {
                ID = entity.ID,
                DivingSiteId = entity.DivingSiteId,
                Name = entity.Name
            };
        }
    }
}
