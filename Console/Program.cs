using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Dorsey.StableMatchmaker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Testing algorithm directly
            /*List<ICandidate> proposers = new List<ICandidate>()
            {
                { new LiteDbCandidate() { Name = "Jack", IsMatched = false, CandidateType = CandidateType.Proposer, Preferences = new List<string>{ "Jenny", "Sarah", "Britney" }}},
                { new LiteDbCandidate() { Name = "Benjamin", IsMatched = false, CandidateType = CandidateType.Proposer, Preferences = new List<string>{ "Sarah", "Britney", "Jenny",}}},
                { new LiteDbCandidate() { Name = "Charles", IsMatched = false, CandidateType = CandidateType.Proposer, Preferences = new List<string>{ "Jenny", "Britney", "Sarah" }}}
            };

            List<ICandidate> proposees = new List<ICandidate>()
            {
                { new LiteDbCandidate() { Name = "Jenny", IsMatched = false, CandidateType = CandidateType.Proposee, Preferences = new List<string>{ "Jack", "Benjamin", "Charles" }}},
                { new LiteDbCandidate() { Name = "Sarah", IsMatched = false, CandidateType = CandidateType.Proposee, Preferences = new List<string>{ "Benjamin", "Jack", "Charles" }}},
                { new LiteDbCandidate() { Name = "Britney", IsMatched = false, CandidateType = CandidateType.Proposee, Preferences = new List<string>{ "Chales", "Benjamin", "Jack" }}}
            };
            var matcher = new Matcher();

            foreach (List<string> match in matcher.Match(proposers, proposees))
            {
                Console.WriteLine($"{match[0]} is matched with {match[1]}");
            }*/

            IMatchSet couples = new LiteDbMatchSet{ Name = "Couples", Capacity = 6, IsReady = false };
            using (var manager = new Manager(new LiteDbCandidateStore(), new LiteDbMatchSetStore(), 
                couples))
            {
                List<ICandidate> proposers = new List<ICandidate>()
                {
                    { new LiteDbCandidate() { Name = "Jack", IsMatched = false, CandidateType = CandidateType.Proposer, Preferences = new List<string>{ "Jenny", "Sarah", "Britney" }, MatchSetId = couples.Id }},
                    { new LiteDbCandidate() { Name = "Benjamin", IsMatched = false, CandidateType = CandidateType.Proposer, Preferences = new List<string>{ "Sarah", "Britney", "Jenny",}, MatchSetId = couples.Id }},
                    { new LiteDbCandidate() { Name = "Charles", IsMatched = false, CandidateType = CandidateType.Proposer, Preferences = new List<string>{ "Jenny", "Britney", "Sarah" }, MatchSetId = couples.Id }}
                };

                List<ICandidate> proposees = new List<ICandidate>()
                {
                    { new LiteDbCandidate() { Name = "Jenny", IsMatched = false, CandidateType = CandidateType.Proposee, Preferences = new List<string>{ "Jack", "Benjamin", "Charles" }, MatchSetId = couples.Id }},
                    { new LiteDbCandidate() { Name = "Sarah", IsMatched = false, CandidateType = CandidateType.Proposee, Preferences = new List<string>{ "Benjamin", "Jack", "Charles" }, MatchSetId = couples.Id }},
                    { new LiteDbCandidate() { Name = "Britney", IsMatched = false, CandidateType = CandidateType.Proposee, Preferences = new List<string>{ "Chales", "Benjamin", "Jack" }, MatchSetId = couples.Id }}
                };
                manager.Start();
                manager.Collect(proposers);
                manager.Collect(proposees);
                await Task.Delay(500);
                if (manager.CanExecute)
                {
                    Console.WriteLine("Ready to execute algorithm.");
                    foreach (List<string> match in manager.ExecuteMatch())
                    {
                        Console.WriteLine($"{match[0]} is matched with {match[1]}.");
                    }
                }
                manager.Terminate();
            }
        }
    }
}
