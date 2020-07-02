using System.Collections.Generic;
using LiteDB;
using System.Linq;

namespace Dorsey.StableMatchmaker
{
    public class LiteDbCandidateStore : ICandidateStore
    {
        private LiteDatabase Database { get; set; }
        private ILiteCollection<LiteDbCandidate> Collection { get; set; }
        
        public LiteDbCandidateStore()
        {
            Database = new LiteDatabase(@"Candidates.db");
            Collection = Database.GetCollection<LiteDbCandidate>("candidates");
        }
        public void Delete(IEnumerable<ICandidate> candidates)
        {
            foreach (ICandidate candidate in candidates)
            {
                Collection.Delete(candidate.Id);
            }
        }
        public IEnumerable<ICandidate> Get(string id)
        {
            return Collection.Find(x => x.MatchSetId == id).ToList();
        }
        public int GetCount(string id)
        {
            var test = Collection.Find(x => x.MatchSetId == id).ToList().Count;
            return test;
        }
        public void Store(IEnumerable<ICandidate> candidates)
        {
            foreach (LiteDbCandidate candidate in candidates)
            {
                Collection.Insert(candidate);
            }
        }
        public void Dispose()
            => Database.Dispose();
    }
}