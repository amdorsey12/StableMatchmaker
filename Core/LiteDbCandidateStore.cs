using System.Collections.Generic;
using LiteDB;
using System.Linq;

namespace Dorsey.StableMatchmaker
{
    public class LiteDbCandidateStore : ICandidateStore
    {
        private LiteDatabase database { get; set; }
        private ILiteCollection<LiteDbCandidate> collection { get; set; }
        
        public LiteDbCandidateStore()
        {
            database = new LiteDatabase(@"Candidates.db");
            collection = database.GetCollection<LiteDbCandidate>("candidates");
        }

        public void Delete(IEnumerable<ICandidate> candidates)
        {
            foreach (ICandidate candidate in candidates)
            {
                collection.Delete(candidate.Id);
            }
        }

        public IEnumerable<ICandidate> Get(string id)
        {
            return collection.Find(x => x.MatchSetId == id).ToList();
        }

        public int GetCount(string id)
        {
            var test = collection.Find(x => x.MatchSetId == id).ToList().Count;
            return test;
        }

        public void Store(IEnumerable<ICandidate> candidates)
        {
            foreach (LiteDbCandidate candidate in candidates)
            {
                collection.Insert(candidate);
            }
        }
        
        public void Dispose()
            => database.Dispose();
    }
}