namespace Dorsey.StableMatchmaker
{
    public class Candidate : ICandidate
    {
        public string Name { get; set; }
        public bool IsMatched { get; set; } = false;
    }
}