namespace Dorsey.StableMatchmaker
{
    public interface IMatchSet
    {
        string Id { get; set; }
        string Name { get; set; }
        int Capacity { get; set; }
        bool IsReady { get; set; }
    }
}