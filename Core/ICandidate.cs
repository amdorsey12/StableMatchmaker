using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface ICandidate
    {
        string Id { get; set; }
        string Name { get; set; }
        bool IsMatched { get; set; }
        CandidateType  CandidateType { get; set; }
        IList<string> Preferences { get; set; }
        string MatchSetId { get; set; }
    }
}