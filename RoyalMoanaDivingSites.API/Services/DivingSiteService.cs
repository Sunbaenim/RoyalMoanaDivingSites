using Microsoft.EntityFrameworkCore;
using RoyalMoanaDivingSites.API.DTO;
using RoyalMoanaDivingSites.API.DTO.DivingSite;
using RoyalMoanaDivingSites.API.DTO.Image;
using RoyalMoanaDivingSites.API.Mappers;
using RoyalMoanaDivingSites.DAL;
using RoyalMoanaDivingSites.DAL.Entities;

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

        public DivingSiteDetailDTO GetDivingSiteById(int id)
        {
            DivingSiteDetailDTO divingSite = _dc.DivingSites
                .Include("Images")
                .Include("Arms")
                .Include("Levels")
                .Where(ds => ds.ID == id)
                .Select(ds => ds.ToDivingSiteDetailDTO())
                .FirstOrDefault()!;

            if (divingSite is null)
            {
                throw new KeyNotFoundException();
            }
            return divingSite;
        }

        private static string GetFileExtension(string base64String)
        {
            return base64String[..5].ToUpper() switch
            {
                "/9J/4" => "jpg",
                "IVBOR" => "png",
                _ => string.Empty,
            };
        }

        private static string GetImageUrlFromBase64(string baseImageUrl, string divingSiteName)
        {
            string base64String = baseImageUrl.Contains(',') ? baseImageUrl.Split(",")[1] : baseImageUrl;
            byte[] base64 = Convert.FromBase64String(base64String);
            string extensionFile = GetFileExtension(base64String);
            Guid guid = Guid.NewGuid();
            string filePath = "assets/diving-sites-images/" + divingSiteName + "-" + guid + "." + extensionFile;
            File.WriteAllBytes("wwwroot/" + filePath, base64);
            return filePath;
        }

        public string CreateDivingSite(DivingSiteAddDTO form)
        {
            if (_dc.DivingSites.ToList().Exists(ds => ds.Name == form.Name))
            {
                throw new ArgumentException($"Le site de plongée \"{form.Name}\"");
            }
            List<ImageAddDTO> images = new();
            try
            {
                foreach (ImageAddDTO image in form.Images)
                {
                    images.Add(new ImageAddDTO
                    {
                        DivingSiteId = image.DivingSiteId,
                        ImageUrl = GetImageUrlFromBase64(image.ImageUrl, form.Name),
                        IsMainImage = image.IsMainImage
                    });
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("The encoding of the image has encountered a problem. The encoding must use Base64");
            }

            _dc.DivingSites.Add(form.ToDivingSite(images));
            _dc.SaveChanges();

            return form.Name;
        }

        public int DeleteDivingSite(int divingSiteId)
        {
            DivingSite? ds = _dc.DivingSites.Find(divingSiteId);
            if (ds is null)
            {
                throw new KeyNotFoundException();
            }
            _dc.DivingSites.Remove(ds);
            _dc.SaveChanges();
            return ds.ID;
        }
    }
}
