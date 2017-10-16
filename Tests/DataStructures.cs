using NUnit.Framework;
using Playground.DataStructures;

namespace Tests
{
    [TestFixture]
    public class DataStructures
    {
        [Test]
        public static void DoubleLinkedList()
        {
            DoublyLinkedList<int> dlist = new DoublyLinkedList<int>();
            dlist.Add(1);
            dlist.Add(2);
            dlist.Add(3);
            dlist.Add(4);
            Assert.That(dlist.Head.Value == 1);
            Assert.That(dlist.Tail.Value == 4);

            dlist.Reverse();

            Assert.That(dlist.Head.Value == 4);
            Assert.That(dlist.Tail.Value == 1);
        }

        [Test]
        public static void LinkedList()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            Assert.That(list.Head.Value == 1);
            Assert.That(list.Tail.Value == 4);

            list.Reverse();

            Assert.That(list.Head.Value == 4);
            Assert.That(list.Tail.Value == 1);

            // return list back
            list.Reverse();

            list.Remove(3);
            Assert.IsNull(list.Find(3));

            var node = list.Find(2);
            Assert.NotNull(node);
            Assert.That(node.Next.Value == 4);

            list.Remove(1);
            list.Remove(4);
            list.Remove(2);
            list.Remove(1);
            list.Add(1);
        }
    }
}
