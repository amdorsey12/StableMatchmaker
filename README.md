# StableMatchmaker
A simple stable matchmaker library with a small sample program implementation using the console and LiteDB.

Current usage:

-Clone or download repo and place it in your project. -Add reference to Dorsey.StableMatchmaker -Create a match set, candidate store, and match set store that suit your needs and obey IMatchset, and IMatchSetStore -Instantiate an instance of Manager, and pass it the match set and stores -Start the manager, pass it candidates until it reaches capacity, and stop it according to your desired program logic.

Sample Program and Output

Program
```cs
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
```
Output
```
Ready to execute algorithm.
Jack is matched with Jenny
Charles is matched with Britney
Benjamin is matched with Sarah
```

A more complete application with a GUI and more practical demonstrations is coming soon.
