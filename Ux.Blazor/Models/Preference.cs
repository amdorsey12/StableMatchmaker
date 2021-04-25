using System;
using System.ComponentModel.DataAnnotations;

namespace Ux.Blazor.Models
{
    public class Preference
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
    }
}