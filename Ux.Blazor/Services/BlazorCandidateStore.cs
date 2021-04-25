using System.Collections.Generic;
using Dorsey.StableMatchmaker;
using LiteDB;
using System.Linq;
using Ux.Blazor.Models;

namespace Ux.Blazor.Services
{
    public class BlazorCandidateStore : ICandidateStore
    {
        private LiteDatabase database { get; set; }
        private ILiteCollection<BlazorCandidate> collection { get; set; }
        
        public BlazorCandidateStore()
        {
            database = new LiteDatabase(@"Candidates.db");
            collection = database.GetCollection<BlazorCandidate>("candidates");
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
            foreach (BlazorCandidate candidate in candidates)
            {
                collection.Insert(candidate);
            }
        }
        
        public void Dispose()
            => database.Dispose();
    }
}