using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dorsey.StableMatchmaker;

namespace Ux.Blazor.Models
{
    public class BlazorCandidate : ICandidate
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        public bool IsMatched { get; set; } = false;
        [Required]
        public CandidateType CandidateType { get; set; }
        public IList<string> Preferences { get; set; } = new List<string>();
        public string MatchSetId  { get; set; }
    }
}