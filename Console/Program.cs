using System;
using System.Collections.Generic;

namespace Dorsey.StableMatchmaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dictionary<ICandidate, IList<string>> setOne = new Dictionary<ICandidate, IList<string>>()
            {
                { new Candidate() { Name = "Jack", IsMatched = false }, new List<string>{ "Jenny", "Sarah", "Karen"  } },
                { new Candidate() { Name = "Benjamin", IsMatched = false }, new List<string>{ "Sarah", "Karen", "Jenny"  } },
                { new Candidate() { Name = "Charles", IsMatched = false }, new List<string>{ "Jenny", "Karen", "Sarah"  } }
            };
            Dictionary<ICandidate, IList<string>> setTwo = new Dictionary<ICandidate, IList<string>>()
            {
                { new Candidate() { Name = "Jenny", IsMatched = false }, new List<string>{ "Jack", "Benjamin", "Charles"  } },
                { new Candidate() { Name = "Sarah", IsMatched = false }, new List<string>{ "Benjamin", "Jack", "Charles"  } },
                { new Candidate() { Name = "Karen", IsMatched = false }, new List<string>{ "Chales", "Benjamin", "Jack"  } }
            };
            var matcher = new Matcher();
            List<List<string>> matches = (List<List<string>>) matcher.Match(setOne, setTwo);
            foreach (List<string> match in matches)
            {
                Console.WriteLine($"{match[0]} is matched with {match[1]}");
                Console.ReadLine();
            }
        }
    }
}
