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
        public static void CoinChange()
        {
            DynamicQ dyn = new DynamicQ();
            int res = dyn.CoinChange(new int[] { 3, 5}, 11);
            Assert.IsTrue(res == 3);
        }

        [Test]
        public static void SearchInRotatedSortedArray()
        {
            int index = ArrayQ.SearchInRotatedSortedArray(new int[] { 7, 1, 2, 3, 4, 5, 6 }, 2);
            Assert.That(index == 2);
        }      
    }
}
