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
        public event Action<IMatchSet> Triggered;
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
                await Task.Delay(500);
                var set = MatchSetStore.Get(MatchSetId);
                var candidates = (List<ICandidate>) CandidateStore.Get();
                if (candidates.Count == set.Capacity)
                {
                    Triggered?.Invoke(set);
                }
                else if(candidates.Count % 2 == 0)
                {
                    Triggered?.Invoke(set);
                }
            }
        }
    }
}