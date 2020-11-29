using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    public class TestResults
    {
        public string Id { get; set; }

        public string FamilyId { get; set; }

        public int Score { get; set; }

        public TestResults(string Id, string FamilyId, int Score)
        {
            this.Id = Id;
            this.FamilyId = FamilyId;
            this.Score = Score;
        }

        public static IEnumerable<TestResults> BestFamilyScore(IEnumerable<TestResults> results)
        {
            return results.GroupBy(x => x.FamilyId).Select(x => x.Aggregate(x.First(), (best, next) => next.Score > best.Score ? best = next : best));
        }
    }
}
