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
        private string MatchSetId { get; set; }
        public event Action<IMatchSet> Ready;
        public event Action<IMatchSet> NotReady;
        public DataMonitor(ICandidateStore candidateStore, IMatchSetStore matchSetStore, string matchSetId)
         {
             this.CandidateStore = candidateStore;
             this.MatchSetStore = matchSetStore;
             this.MatchSetId = matchSetId;
         }

        public async void Monitor()
        {
            while (IsRunning)
            {
                await Task.Delay(100);
                var set = MatchSetStore.Get(MatchSetId);
                var candidates = CandidateStore.Get(set.Id);
                if (candidates.Count == set.Capacity)
                {
                    Ready?.Invoke(set);
                }
                else if(candidates.Count % 2 == 0 && candidates.Count > 0)
                {
                    Ready?.Invoke(set);
                }
                else
                {
                    NotReady?.Invoke(set);
                }
            }
        }
    }
}