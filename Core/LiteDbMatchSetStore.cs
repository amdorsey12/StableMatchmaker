using System.Collections.Generic;
using LiteDB;

namespace Dorsey.StableMatchmaker
{
    public class LiteDbMatchSetStore : IMatchSetStore
    {
        private LiteDatabase Database { get; set; }
        private ILiteCollection<IMatchSet> Collection { get; set; }
        
        public LiteDbMatchSetStore()
        {
            Database = new LiteDatabase(@"MatchSets.db");
            Collection = Database.GetCollection<IMatchSet>("matchsets");
        }
        public void Delete(IMatchSet set)
        {
            Collection.Delete(set.Id);
        }
        public IMatchSet Get(string id)
        {
            return Collection.FindOne(x => x.Id == id);
        }

        public void Store(IMatchSet set)
        {
            Collection.Insert(set);
        }
        public void Dispose()
            => Database.Dispose();
    }
}