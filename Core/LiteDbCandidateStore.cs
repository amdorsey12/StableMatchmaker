using System.Collections.Generic;
using LiteDB;

namespace Dorsey.StableMatchmaker
{
    public class LiteDbCandidateStore : ICandidateStore
    {
        private LiteDatabase Database { get; set; }
        private ILiteCollection<ICandidate> Collection { get; set; }
        
        public LiteDbCandidateStore()
        {
            Database = new LiteDatabase(@"Candidates.db");
            Collection = Database.GetCollection<ICandidate>("candidates");
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
            return Collection.Find(x => x.MatchSetId == id);
        }
        public void Store(IEnumerable<ICandidate> candidates)
        {
            Collection.Insert(candidates);
        }
        public void Dispose()
            => Database.Dispose();
    }
}