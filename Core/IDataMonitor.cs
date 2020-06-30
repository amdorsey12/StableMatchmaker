using System;

namespace Dorsey.StableMatchmaker 
{
    public interface IDataMonitor
    {
        bool IsRunning { get; set; }
        void Monitor();
    }
}