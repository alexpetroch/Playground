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

        [Test]
        public static void CheckOverlap()
        {
            OverlapSolution overlap = new OverlapSolution();
            overlap.AddInterval(new Interval() { StartTime = 1, EndTime = 3 });
            overlap.AddInterval(new Interval() { StartTime = 3, EndTime = 5 });
            Assert.That(overlap.CheckOverlap() == false);
            Assert.That(overlap.MinRooms() == 1);

            overlap.AddInterval(new Interval() { StartTime = 4, EndTime = 6 });
            Assert.That(overlap.CheckOverlap() == true);
            Assert.That(overlap.MinRooms() == 2);

            OverlapSolution overlap1 = new OverlapSolution();
            overlap1.AddInterval(new Interval() { StartTime = 1, EndTime = 10 });
            overlap1.AddInterval(new Interval() { StartTime = 2, EndTime = 8 });
            overlap1.AddInterval(new Interval() { StartTime = 9, EndTime = 12 });
            Assert.That(overlap1.MinRooms() == 2);
        }

        [Test]
        public static void MaxDoubleSliceSum()
        {
            Assert.That(MathQ.MaxDoubleSliceSum(new int[] {3, 2, 6, -1, 4, 5, -1, 2 }) == 17);
        }

        [Test]
        public static void IsAnagram()
        {
            Assert.That(StringQ.IsAnagram("abcd", "dbac") == true);
            Assert.That(StringQ.IsAnagram("abcd", "dbac1") == false);
            Assert.That(StringQ.IsAnagram("abcde", "dbacf") == false);
        }

        [Test]
        public static void Dominator()
        {
            Assert.That(ArrayQ.Dominator(new int[] {1, 2, 1, 3, 1 }) == 4 );
            Assert.That(ArrayQ.Dominator(new int[] { 1, 2, 3, 4, 1 }) == -1);
        }

        [Test]
        public static void HalfReverse()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);

            LinkedListQ<int> listQ = new LinkedListQ<int>(list);
            listQ.HalfReverse();
        }
        
    }
}
