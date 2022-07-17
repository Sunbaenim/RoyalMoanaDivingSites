namespace RoyalMoanaDivingSites.DAL.Entities
{
    public class Arm
    {
        public int ID { get; set; }
        public int DivingSiteId { get; set; }
        public DivingSite DivingSite { get; set; }
        public string Name { get; set; }
    }
}
