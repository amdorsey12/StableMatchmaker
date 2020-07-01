using System;
using System.Collections.Generic;
using System.Linq;

namespace Dorsey.StableMatchmaker
{
    public class Matcher : IMatcher
    {
        public IEnumerable<IEnumerable<string>> Match(IEnumerable<ICandidate> proposers, IEnumerable<ICandidate> proposee)
        {
            var matches = new List<List<string>>();
            string currentMatch = String.Empty;
            while (proposers.Where(x => x.IsMatched == false).Count() > 0)
            {
                var proposer = proposers.Where(x => x.IsMatched == false).FirstOrDefault();
                var potentialMatch = proposee.Where(x => x.Name == proposer.Preferences.FirstOrDefault()).FirstOrDefault();
                if (!potentialMatch.IsMatched)
                {
                    matches.Add(new List<string>(){proposer.Name, potentialMatch.Name});
                    currentMatch = proposer.Name;
                    proposers.Where(x => x.Name == proposer.Name).FirstOrDefault().IsMatched = true;
                    proposee.Where(x => x.Name == potentialMatch.Name).FirstOrDefault().IsMatched = true;
                }
                else
                {
                    if (potentialMatch.Preferences.IndexOf(proposer.Name) < potentialMatch.Preferences.IndexOf(currentMatch))
                    {
                        matches.RemoveAll( x => x.Any( s => s.Contains(potentialMatch.Name)));
                        matches.Add(new List<string>() {proposer.Name, potentialMatch.Name});
                        proposers.Where(x => x.Name == proposer.Name).FirstOrDefault().IsMatched = true;
                        proposers.Where(x => x.Name == currentMatch).FirstOrDefault().IsMatched = false;
                    }
                    else 
                    {
                        proposer.Preferences.Remove(potentialMatch.Name);
                    }
                }
            }
            return matches;
        }
    }
}
