using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public class LiteDbCandidate : ICandidate
    {
        [LiteDB.BsonId]
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public bool IsMatched { get; set; } = false;
        public CandidateType CandidateType { get; set; }
        public IList<string> Preferences { get; set; }
        public string MatchSetId { get; set; }
    }
}