using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ICandidate> proposers = new List<ICandidate>()
            {
                { new LiteDbCandidate() { Name = "Jack", IsMatched = false, Preferences = new List<string>{ "Jenny", "Sarah", "Karen" }}},
                { new LiteDbCandidate() { Name = "Benjamin", IsMatched = false, Preferences = new List<string>{ "Sarah", "Karen", "Jenny" }}},
                { new LiteDbCandidate() { Name = "Charles", IsMatched = false, Preferences = new List<string>{ "Jenny", "Karen", "Sarah" }}}
            };

            List<ICandidate> proposees = new List<ICandidate>()
            {
                { new LiteDbCandidate() { Name = "Jenny", IsMatched = false, Preferences = new List<string>{ "Jack", "Benjamin", "Charles" }}},
                { new LiteDbCandidate() { Name = "Sarah", IsMatched = false, Preferences = new List<string>{ "Benjamin", "Jack", "Charles" }}},
                { new LiteDbCandidate() { Name = "Karen", IsMatched = false, Preferences = new List<string>{ "Chales", "Benjamin", "Jack" }}}
            };

            var matcher = new Matcher();
            
            foreach (List<string> match in matcher.Match(proposers, proposees))
            {
                Console.WriteLine($"{match[0]} is matched with {match[1]}");
            }
        }
    }
}
