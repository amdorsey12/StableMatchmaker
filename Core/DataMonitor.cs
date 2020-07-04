using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dorsey.StableMatchmaker
{
    public class DataMonitor : IDataMonitor
    {
        public bool IsRunning { get; set; }
        private ICandidateStore CandidateStore { get; set; }
        private IMatchSetStore MatchSetStore { get; set; }
        private IMatchSet MatchSet { get; set; }
        public event Action<IMatchSet> Ready;
        public event Action<IMatchSet> NotReady;

        public DataMonitor(ICandidateStore candidateStore, IMatchSetStore matchSetStore, IMatchSet matchSet)
         {
             this.CandidateStore = candidateStore;
             this.MatchSetStore = matchSetStore;
             this.MatchSet = matchSet;
         }

        public async void Monitor()
        {
            while (IsRunning)
            {
                await Task.Delay(100);
                var count = CandidateStore.GetCount(MatchSet.Id);
                if (count == MatchSet.Capacity)
                {
                    Ready?.Invoke(MatchSet);
                }
                else if (count % 2 == 0)
                {
                    Ready?.Invoke(MatchSet);
                }
                else 
                {
                    NotReady?.Invoke(MatchSet);
                }
            }
        }
    }
}