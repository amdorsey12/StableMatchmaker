using System.Collections.Generic;
using Dorsey.StableMatchmaker;
using LiteDB;

namespace Ux.Blazor.Services
{
    public class BlazorMatchSetStore : IMatchSetStore
    {
        private LiteDatabase database { get; set; }
        private ILiteCollection<IMatchSet> collection { get; set; }
        
        public BlazorMatchSetStore()
        {
            database = new LiteDatabase(@"MatchSets.db");
            collection = database.GetCollection<IMatchSet>("matchsets");
        }
        
        public void Delete(IMatchSet set)
        {
            collection.Delete(set.Id);
        }

        public IMatchSet Get(string id)
        {
            return collection.FindOne(x => x.Id == id);
        }

        public void Store(IMatchSet set)
        {
            collection.Insert(set);
        }

        public void MarkReady(string id)
        {
            var set = collection.FindById(id);
            set.IsReady = true;
            collection.Update(set);
        }

        public void MarkNotReady(string id)
        {
            var set = collection.FindById(id);
            set.IsReady = false;
            collection.Update(set);
        }

        public void Dispose()
            => database.Dispose();
    }
}