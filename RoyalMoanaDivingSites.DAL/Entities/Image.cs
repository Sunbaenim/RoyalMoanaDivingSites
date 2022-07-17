namespace RoyalMoanaDivingSites.DAL.Entities
{
    public class Image
    {
        public int ID { get; set; }
        public int DivingSiteId { get; set; }
        public DivingSite DivingSite { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMainImage { get; set; }
    }
}
