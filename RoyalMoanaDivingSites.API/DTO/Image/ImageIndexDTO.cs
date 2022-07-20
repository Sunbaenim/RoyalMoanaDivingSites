namespace RoyalMoanaDivingSites.API.DTO.Image
{
    public class ImageIndexDTO
    {
        public int ID { get; set; }
        public int DivingSiteId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMainImage { get; set; }
    }
}
