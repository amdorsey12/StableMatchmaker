namespace Dorsey.StableMatchmaker
{
    public class LiteDbMatchSet : IMatchSet
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsReady { get; set; }
    }
}