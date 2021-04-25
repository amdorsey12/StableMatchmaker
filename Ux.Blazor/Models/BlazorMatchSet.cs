using System;
using System.ComponentModel.DataAnnotations;
using Dorsey.StableMatchmaker;

namespace Ux.Blazor.Models
{
    public class BlazorMatchSet : IMatchSet
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        [Required]
        public int Capacity { get; set; }
        public bool IsReady { get; set; } = false;
    }
}