using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public interface IManager : IDisposable
    {
        void Start();
        void Collect(IEnumerable<ICandidate> candidates);
        void Terminate();
        IEnumerable<IEnumerable<string>> ExecuteMatch();
    }

    public static class ManagerUtils
    {
        public static void Collect(this IManager manager, params ICandidate[] candidates)
            => manager.Collect((IEnumerable<ICandidate>) candidates);
    }
}