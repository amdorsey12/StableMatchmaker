using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface IMatcher
    {
        IEnumerable<IEnumerable<string>> Match(IDictionary<ICandidate, IList<string>> setOne, IDictionary<ICandidate, IList<string>> setTwo);
    }
}