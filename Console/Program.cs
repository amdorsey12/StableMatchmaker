using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<ICandidate> proposers = new List<ICandidate>()
            {
                { new Candidate() { Name = "Jack", IsMatched = false, Preferences = new List<string>{ "Jenny", "Sarah", "Karen" }}},
                { new Candidate() { Name = "Benjamin", IsMatched = false, Preferences = new List<string>{ "Sarah", "Karen", "Jenny" }}},
                { new Candidate() { Name = "Charles", IsMatched = false, Preferences = new List<string>{ "Jenny", "Karen", "Sarah" }}}
            };

            List<ICandidate> proposees = new List<ICandidate>()
            {
                { new Candidate() { Name = "Jenny", IsMatched = false, Preferences = new List<string>{ "Jack", "Benjamin", "Charles" }}},
                { new Candidate() { Name = "Sarah", IsMatched = false, Preferences = new List<string>{ "Benjamin", "Jack", "Charles" }}},
                { new Candidate() { Name = "Karen", IsMatched = false, Preferences = new List<string>{ "Chales", "Benjamin", "Jack" }}}
            };

            var matcher = new Matcher();
            List<List<string>> matches = (List<List<string>>) matcher.Match(proposers, proposees);
            foreach (List<string> match in matches)
            {
                Console.WriteLine($"{match[0]} is matched with {match[1]}");
                Console.ReadLine();
            }
        }
    }
}
