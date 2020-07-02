using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface ICandidateStore : IDisposable
    {
        IEnumerable<ICandidate> Get(string id);
        int GetCount(string id);
        void Delete(IEnumerable<ICandidate> candidates);
        void Store(IEnumerable<ICandidate> candidates);
    }

    public static class CandidateStoreUtils
    {
        public static void Delete(this ICandidateStore store, params ICandidate[] candidates)
            => store.Delete((IEnumerable<ICandidate>) candidates);

        public static void Store(this ICandidateStore store, params ICandidate[] candidates)
            => store.Store((IEnumerable<ICandidate>) candidates);
    }
}