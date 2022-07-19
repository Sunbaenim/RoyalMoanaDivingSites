namespace RoyalMoanaDivingSites.API.DTO
{
    public class IndexDTO<T> where T : class
    {
        public IndexDTO(int count, IEnumerable<T> results)
        {
            Count = count;
            Results = results;
        }

        public int Count { get; private set; }
        public IEnumerable<T> Results { get; private set; }
    }
}
