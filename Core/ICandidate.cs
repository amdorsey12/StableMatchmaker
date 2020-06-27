namespace Dorsey.StableMatchmaker
{
    public interface ICandidate
    {
        string Name { get; set; }
        bool IsMatched { get; set; }
    }
}