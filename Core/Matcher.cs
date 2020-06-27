using System;
using System.Collections.Generic;
using System.Linq;

namespace Dorsey.StableMatchmaker
{
    public class Matcher : IMatcher
    {
        public IEnumerable<IEnumerable<string>> Match(IDictionary<ICandidate, IList<string>> setOne, IDictionary<ICandidate, IList<string>> setTwo)
        {
            var matches = new List<List<string>>();
            string currentMatch = String.Empty;
            while (setOne.Where(x => x.Key.IsMatched == false).Count() > 0)
            {
                var suitor = setOne.Where(x => x.Key.IsMatched == false).FirstOrDefault();
                Candidate potentialMatch = (Candidate) setTwo.Where(x => x.Key.Name == suitor.Value.FirstOrDefault()).FirstOrDefault().Key;
                if (!potentialMatch.IsMatched)
                {
                    matches.Add(new List<string>(){suitor.Key.Name, potentialMatch.Name});
                    currentMatch = suitor.Key.Name;
                    setOne.Keys.Where(x => x.Name == suitor.Key.Name).FirstOrDefault().IsMatched = true;
                    setTwo.Keys.Where(x => x.Name == potentialMatch.Name).FirstOrDefault().IsMatched = true;
                }
                else
                {
                    if (setTwo[potentialMatch].IndexOf(suitor.Key.Name) < setTwo[potentialMatch].IndexOf(currentMatch))
                    {
                        matches.RemoveAll( x => x.Any( s => s.Contains(potentialMatch.Name)));
                        matches.Add(new List<string>() {suitor.Key.Name, potentialMatch.Name});
                        setOne.Keys.Where(x => x.Name == suitor.Key.Name).FirstOrDefault().IsMatched = true;
                        setOne.Keys.Where(x => x.Name == currentMatch).FirstOrDefault().IsMatched = false;
                    }
                    else 
                    {
                        setOne[suitor.Key].Remove(potentialMatch.Name);
                    }
                }
            }
            return matches;
        }
    }
}
