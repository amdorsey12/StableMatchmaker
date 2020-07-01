using System;

namespace Dorsey.StableMatchmaker 
{
    public interface IDataMonitor
    {
        bool IsRunning { get; set; }
        event Action<IMatchSet> Ready;
        event Action<IMatchSet> NotReady;
        void Monitor();
    }
}