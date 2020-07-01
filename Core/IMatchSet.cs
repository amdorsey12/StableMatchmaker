namespace Dorsey.StableMatchmaker
{
    public interface IMatchSet
    {
        string Id { get; set; }
        int Capacity { get; set; }
    }
}