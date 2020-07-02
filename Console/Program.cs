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

            //Testing algorithm directly
            /*var matcher = new Matcher();

            foreach (List<string> match in matcher.Match(proposers, proposees))
            {
                Console.WriteLine($"{match[0]} is matched with {match[1]}");
            }*/

            var manager = new Manager(new LiteDbCandidateStore(), new LiteDbMatchSetStore(), 
                new LiteDbMatchSet{ Id = Guid.NewGuid().ToString(), Name = "Couples", Capacity = 6, IsReady = false});
            manager.Start();
            manager.Collect(proposers);
            manager.Collect(proposees);
            await Task.Delay(2000);
            if (manager.CanExecute)
            {
                Console.WriteLine("Ready to execute algorithm.");
                foreach (List<string> match in manager.ExecuteMatch())
                {
                    Console.WriteLine($"{match[0]} is matched with {match[1]}");
                }
            }
            manager.Terminate();
        }
    }
}
