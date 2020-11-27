using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace LINQ.Tests
{
    public class TestResultsTests
    {
        [Fact]
        public void TestResultsWork()
        {
            var t1 = new TestResults("f1_1", "f1", 1);
            var t2 = new TestResults("f1_2", "f1", 4);
            var t3 = new TestResults("f2_1", "f2", 2);
            var t4 = new TestResults("f2_2", "f2", 5);
            var t5 = new TestResults("f2_3", "f2", 7);
            var t6 = new TestResults("f3_1", "f3", 2);
            var t7 = new TestResults("f3_2", "f3", 6);

            List<TestResults> results = new List<TestResults> { t1, t2, t3, t4, t5, t6, t7 };
   
            Assert.Collection(TestResults.BestFamilyScore(results),
                 item => Assert.Equal(t2, item),
                 item => Assert.Equal(t5, item),
                 item => Assert.Equal(t7, item));
        }
    }
}