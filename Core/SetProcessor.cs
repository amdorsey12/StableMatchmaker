using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public class SetProcessor : ISetProcessor
    {
        public Tuple<IDictionary<ICandidate, IList<string>>, IDictionary<ICandidate, IList<string>>> Process(IDictionary<ICandidate, IList<string>> Data)
        {
            IDictionary<ICandidate, IList<string>> proposers = new Dictionary<ICandidate, IList<string>>();
            IDictionary<ICandidate, IList<string>> proposees = new Dictionary<ICandidate, IList<string>>();
            foreach (var datum in Data)
            {
                if (datum.Key.CandidateType == CandidateType.Propoer)
                {
                    proposers.Add(datum);
                }
                else
                {
                    proposees.Add(datum);
                }
            }
            return Tuple.Create(proposers, proposees);
        }
    }
}