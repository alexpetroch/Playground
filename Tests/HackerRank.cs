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
    }
}
