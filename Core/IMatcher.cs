using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface IMatcher
    {
        IEnumerable<IEnumerable<string>> Match(IDictionary<ICandidate, IEnumerable<string>> setOne, IDictionary<ICandidate, IEnumerable<string>> setTwo);
    }
}