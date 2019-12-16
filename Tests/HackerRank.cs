using NUnit.Framework;
using Playground.Interview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    [Category("HackerRank")]
    class HackerRank
    {
        // Complete the powerSum function below.

        [Test]
        public static void PowerSum()
        {
            Assert.That(MathQ.PowerSum(100, 2) == 2);
        }

        [Test]
        public static void MaxSubsetSum()
        {
            int[] arr = new int[] {3, 5, -7, 8, 10};
            Assert.That(DynamicQ.MaxSubsetSum(arr) == 15);
        }
        
        [Test]
        public static void MinimumBrabes()
        {
            int[] arr = new int[] { 1, 2, 5, 3, 4 };
            Assert.That(ArrayQ.minimumBribes(arr) == 2);
        }
    }
}
