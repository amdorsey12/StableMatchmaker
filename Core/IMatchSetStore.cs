using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface IMatchSetStore : IDisposable
    {
        IMatchSet Get(string id);
        void Delete(IMatchSet set);
        void Store(IMatchSet set);
    }
}