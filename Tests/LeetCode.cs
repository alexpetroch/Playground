using NUnit.Framework;
using Playground.Interview;

namespace Tests
{
    class LeetCode
    {
        [Test]
        public static void SwapNodesInPairs()
        {
            Playground.DataStructure.LinkedList<int> list1 = new Playground.DataStructure.LinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            var listQ = new LinkedListQ<int>(list1);
            listQ.SwapNodesInPairs();
            Assert.That(listQ.Head.Value == 2);


            list1 = new Playground.DataStructure.LinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            listQ = new LinkedListQ<int>(list1);
            listQ.SwapNodesInPairs();
            Assert.That(listQ.Head.Value == 2);
        }

        [Test]
        public static void TriplesInGeometricProgression()
        {
            System.Collections.Generic.List<long> list = new System.Collections.Generic.List<long>();
            list.AddRange(new long[] { 1, 2, 1, 2, 4 });

            Assert.That(DictionaryQ.CountTriplets(list, 2) == 3);
        }
    }
}
