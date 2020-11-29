using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        public static void Main()
        {
            var t1 = new TestResults("f1_1", "f1", 1);
            var t2 = new TestResults("f1_2", "f1", 4);
            var t3 = new TestResults("f2_1", "f2", 2);
            var t4 = new TestResults("f2_2", "f2", 5);
            var t5 = new TestResults("f2_3", "f2", 7);
            var t6 = new TestResults("f3_1", "f3", 2);
            var t7 = new TestResults("f3_2", "f3", 6);

            List<TestResults> results = new List<TestResults> { t1, t2, t3, t4, t5, t6, t7 };
            List<TestResults> seed = new List<TestResults> { };

            var a = results.GroupBy(x => x.FamilyId).Select(x => x.Aggregate(x.First(), (best, next) => next.Score > best.Score ? best = next : best));
        }
    }
}