using System;
using System.Collections.Generic;
using System.Linq;
using Dorsey.StableMatchmaker;
using Ux.Blazor.Models;

namespace Ux.Blazor.Services
{
    public class BlazorInMemoryCandidateStore : ICandidateStore
    {
        private List<BlazorCandidate> candidates { get; set; }
        public BlazorInMemoryCandidateStore()
        {
            candidates = new List<BlazorCandidate>();
        }
        public void Delete(IEnumerable<ICandidate> candidates)
        {
            foreach(BlazorCandidate candidate in candidates)
            {
                this.candidates.Remove(this.candidates.Where(x => x.Id == candidate.Id).FirstOrDefault());
            }
        }

        public void Dispose()
            =>this.Dispose();

        public IEnumerable<ICandidate> Get(string id)
        {
            return candidates.Where(x => x.MatchSetId == id).ToList();
        }

        public int GetCount(string id)
        {
            return (candidates.Where(x => x.MatchSetId == id).Count());
        }

        public void Store(IEnumerable<ICandidate> candidates)
        {
            foreach (BlazorCandidate candidate in candidates)
            {
                this.candidates.Add(candidate);
                Console.WriteLine($"I have stored {candidate.Name}.");
            }
            foreach (var c in this.candidates)
            {
                Console.WriteLine(c.Name);
            }       
        }
    }
}