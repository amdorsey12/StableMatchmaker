using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface ICandidate
    {
        string Name { get; set; }
        bool IsMatched { get; set; }
        CandidateType  CandidateType { get; set; }
        IList<string> Preferences { get; set; }
    }
}