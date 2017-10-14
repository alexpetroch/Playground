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
    }
}
