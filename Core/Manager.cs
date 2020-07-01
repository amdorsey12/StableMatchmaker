using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    public class Manager : IManager
    {
        private ICandidateStore CandidateStore { get; set; }
        private IMatchSetStore MatchSetStore { get; set; }
        private IDataMonitor Monitor { get; set; }
        private ISetProcessor Processor { get; set; }
        private IMatcher Matcher { get; set; }
        private IMatchSet Set { get; set; }
        public Manager(ICandidateStore candidateStore, IMatchSetStore matchSetStore, IMatchSet set)
        {
            this.CandidateStore = candidateStore;
            this.MatchSetStore = matchSetStore;
            this.Set = set;
            this.Monitor = new DataMonitor(CandidateStore, MatchSetStore, Set.Id);
            this.Processor = new SetProcessor();
            this.Matcher = new Matcher();
            Start();
        }
        public IEnumerable<IEnumerable<string>> ExecuteMatch()
        {
            var processedData = Processor.Process(CandidateStore.Get(Set.Id));
            return Matcher.Match(processedData.Item1, processedData.Item2);
        }

        public void Start()
        {
            if (Monitor.IsRunning)
            {
                throw new InvalidOperationException();
            }
            else 
            {
                Monitor.Monitor();
                Monitor.Ready += Ready;
                Monitor.NotReady += NotReady;
            }
        }
        public void Collect(IEnumerable<ICandidate> candidates)
        {
            CandidateStore.Store(candidates);
        }
        public void Terminate()
            => Monitor.IsRunning = false;
        public void Ready(IMatchSet matchSet)
        {
            MatchSetStore.MarkReady(matchSet.Id);
        }
        public void NotReady(IMatchSet matchSet)
        {
            MatchSetStore.MarkNotReady(matchSet.Id);
        }
        public void Dispose()
        {
            CandidateStore.Dispose();
            MatchSetStore.Dispose();
        }
    }
}