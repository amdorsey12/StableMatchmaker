using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface ISetProcessor
    {
        Tuple<IList<ICandidate>, IList<ICandidate>> Process(IEnumerable<ICandidate> candidates);
    }
}