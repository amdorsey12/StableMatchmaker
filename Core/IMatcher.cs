using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface IMatcher
    {
        IEnumerable<IEnumerable<string>> Match(IEnumerable<ICandidate> proposers, IEnumerable<ICandidate> proposees);
    }
}