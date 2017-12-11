using NUnit.Framework;
using Playground.DataStructure;
using Playground.Interview;
using System.Linq;

namespace Tests
{
    [TestFixture]
    [Category("Codility")]
    class Codility
    {
        [Test]
        public static void LongestZero()
        {
            Assert.That(Bits.LongestZeroAroundOnes(20) == 1);
        }

        [Test]
        public static void RotateCycle()
        {
            int[] orig = { 5, -1000 };
            int[] rotate = { -1000, 5 };
            int[] result = SimpleArray.RotateCycle(orig, 1);            
            Assert.That(rotate.SequenceEqual(result));
        }

        [Test]
        public static void StrStr()
        {            
            Assert.That(StringQ.StrStr("bbaabbbbbaabbaabbbbbbabbbabaabbbabbabbbbababbbabbabaaababbbaabaaaba", "babaaa") == 48);
        }

        [Test]
        public static void MaxProfit()
        {
            int[] stocks = new int[] { 23171, 21011, 21123, 21366, 21013, 21367 };
            Assert.That(MathQ.MaxProfit(stocks) == 356); // second and fourth elements
        }

        [Test]
        public static void AbsDistinct()
        {
            int[] arr = new int[] { -3, -3, 3, 3 };
            Assert.That(ArrayQ.AbsDistinct(arr) == 1);

            Assert.That(ArrayQ.AbsDistinct(new int[] { -5, -3, -1, 0, 3, 6}) == 5);
        }
    }
}
