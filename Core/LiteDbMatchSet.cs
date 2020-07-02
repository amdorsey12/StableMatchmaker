using System;

namespace Dorsey.StableMatchmaker
{
    public class LiteDbMatchSet : IMatchSet
    {
        [LiteDB.BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public bool IsReady { get; set; }
    }
}