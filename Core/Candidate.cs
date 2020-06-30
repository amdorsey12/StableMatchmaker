using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public class Candidate : ICandidate
    {
        public string Name { get; set; }
        public bool IsMatched { get; set; } = false;
        public CandidateType CandidateType { get; set; }
        public IList<string> Preferences { get; set; }
    }
}