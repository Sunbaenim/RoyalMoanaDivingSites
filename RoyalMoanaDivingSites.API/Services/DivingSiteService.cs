using Microsoft.EntityFrameworkCore;
using RoyalMoanaDivingSites.API.DTO;
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

        public IndexDTO<DivingSiteIndexDTO> GetAllDivingSites(DivingSiteFilterDTO filter)
        {
            IEnumerable<DivingSiteIndexDTO> results = _dc.DivingSites
                .Include("Images")
                .Include("Arms")
                .Include("Levels")
                .Where(ds => filter.Name == null || ds.Name.Contains(filter.Name))
                .Where(ds => filter.Level == null || ds.Levels.Any(l => l.LevelNumber == filter.Level))
                .Where(ds => filter.Tide == null || ds.Tide == filter.Tide)
                .Where(ds => filter.Arm == null || ds.Arms.Any(a => a.Name == filter.Tide))
                .Where(ds => filter.Current == null || ds.Current == filter.Current)
                .Where(ds => filter.IsSnorkeling == null || ds.IsSnorkeling == filter.IsSnorkeling)
                .Where(ds => filter.IsInitiation == null || ds.IsInitiation == filter.IsInitiation)
                .Where(ds => filter.IsForDisabledPerson == null || ds.IsForDisabledPerson == filter.IsForDisabledPerson)
                .Where(ds => filter.IsSpecialDiving == null || ds.IsSpecialDiving == filter.IsSpecialDiving)
                .Select(ds => ds.ToDivingSiteIndexDTO());

            int count = results.Count();

            results = results
                .Skip(filter.Offset)
                .Take(filter.Limit);

            return new IndexDTO<DivingSiteIndexDTO>(count, results);
        }
    }
}
