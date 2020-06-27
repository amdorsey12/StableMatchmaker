using System;
using System.Collections.Generic;
using System.Linq;

namespace Dorsey.StableMatchmaker
{
    public class Matcher : IMatcher
    {
        public IEnumerable<IEnumerable<string>> Match(IDictionary<ICandidate, IEnumerable<string>> setOne, IDictionary<ICandidate, IEnumerable<string>> setTwo)
        {
            var matches = new List<List<string>>();
            while (setOne.Where(x => x.Key.IsMatched == false).Count() > 0)
            {
                Candidate potentialMatch = (Candidate) setTwo.Keys.Where(x => x.Name == setOne.First().Value.First()).First();
                if (!potentialMatch.IsMatched)
                {
                    matches.Add(new List<string>(){potentialMatch.Name, setOne.Keys.First().Name});
                }
            }
            return matches;
        }
    }
}
