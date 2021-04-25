using System.Collections.Generic;
using System.Linq;
using Dorsey.StableMatchmaker;
using Ux.Blazor.Models;

namespace Ux.Blazor.Services
{
    public class BlazorInMemoryMatchSetStore : IMatchSetStore
    {
        private List<IMatchSet> sets { get; set; }
        public BlazorInMemoryMatchSetStore()
            => sets = new List<IMatchSet>();
        
        public void Delete(IMatchSet set)
            => sets.Remove(sets.Where(x => x.Id == set.Id).FirstOrDefault());
        

        public void Dispose()
            => this.Dispose();

        public IMatchSet Get(string id)
        {
            return sets.Where(x => x.Id == id).FirstOrDefault();
        }

        public void MarkNotReady(string id)
            => sets.Where(x => x.Id == id).FirstOrDefault().IsReady = false;

        public void MarkReady(string id)
            => sets.Where(x => x.Id == id).FirstOrDefault().IsReady = true;

        public void Store(IMatchSet set)
            => sets.Add(set);
    }
}