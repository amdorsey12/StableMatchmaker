using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public class SetProcessor : ISetProcessor
    {
        public Tuple<IList<ICandidate>, IList<ICandidate>> Process(IEnumerable<ICandidate> candidates)
        {
            IList<ICandidate> proposers = new List<ICandidate>();
            IList<ICandidate> proposees = new List<ICandidate>();
            foreach (var candidate in candidates)
            {
                if (candidate.CandidateType == CandidateType.Propoer)
                {
                    proposers.Add(candidate);
                }
                else
                {
                    proposees.Add(candidate);
                }
            }
            return Tuple.Create(proposers, proposees);
        }
    }
}