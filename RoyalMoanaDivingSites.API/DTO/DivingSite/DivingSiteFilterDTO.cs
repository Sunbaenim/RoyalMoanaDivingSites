namespace RoyalMoanaDivingSites.API.DTO.DivingSite
{
    public class DivingSiteFilterDTO
    {
        public int Limit { get; set; } = 10;
        public int Offset { get; set; } = 0;
        public string? Name { get; set; }
        public int? Level { get; set; }
        public string? Tide { get; set; }
        public string? Arm { get; set; }
        public string? Current { get; set; }
        public bool? IsSnorkeling { get; set; }
        public bool? IsInitiation { get; set; }
        public bool? IsForDisabledPerson { get; set; }
        public bool? IsSpecialDiving { get; set; }
    }
}
