using Microsoft.EntityFrameworkCore;
using RoyalMoanaDivingSites.API.DTO.DivingSite;
using RoyalMoanaDivingSites.API.Mappers;
using RoyalMoanaDivingSites.DAL;

namespace RoyalMoanaDivingSites.API.Services
{
    public class DivingSiteService
    {
        private readonly RmdsDbContext _dc;

        public DivingSiteService(RmdsDbContext dc)
        {
            _dc = dc;
        }

        public IEnumerable<DivingSiteIndexDTO> GetAllDivingSites()
        {
            return _dc.DivingSites.Include("Arms")
                .Include("Images")
                .Select(ds => ds.ToDivingSiteIndexDTO());
        }
    }
}
