using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface ISetProcessor
    {
        Tuple<IDictionary<ICandidate, IList<string>>, IDictionary<ICandidate, IList<string>>> Process(IDictionary<ICandidate, IList<string>> Data);
    }
}