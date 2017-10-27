using NUnit.Framework;
using Playground.DataStructure;
using System;

namespace Tests
{
    [TestFixture]
    [Category("DataStructures")]
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

            dlist.Reverse();

            dlist.Remove(3);
            var node = dlist.Find(2);
            Assert.That(node.Next.Value == 4);

            node = dlist.Find(1);
            dlist.Remove(node);

            Assert.That(dlist.Head.Value == 2);            
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

        [Test]
        public static void Stack()
        {
            Stack<int> stack = new Stack<int>();
            StackTest(stack);

            StackL<int> stackL = new StackL<int>();
            StackTest(stackL);
        }

        private static void StackTest(IStack<int> stack)
        {
            Assert.Throws<InvalidOperationException>(() => stack.Pop());

            stack.Push(1);
            Assert.That(stack.Peek() == 1);

            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Assert.That(stack.Pop() == 4);
            Assert.That(stack.Pop() == 3);
            stack.Push(3);
            Assert.That(stack.Pop() == 3);
            Assert.That(stack.Pop() == 2);
            Assert.That(stack.Pop() == 1);

            Assert.Throws<InvalidOperationException>(() => stack.Peek());
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Test]
        public static void Queue()
        {
            Queue<int> queue = new Queue<int>();
            QueueTest(queue);

            QueueL<int> queueL = new QueueL<int>();
            QueueTest(queueL);
        }

        private static void QueueTest(IQueue<int> queue)
        {
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());

            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.That(queue.Peek() == 1);
            Assert.That(queue.Dequeue() == 1);
            Assert.That(queue.Dequeue() == 2);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Assert.That(queue.Dequeue() == 1);
            queue.Enqueue(1);
            Assert.That(queue.Dequeue() == 2);
            Assert.That(queue.Dequeue() == 3);
            Assert.That(queue.Dequeue() == 4);
            Assert.That(queue.Dequeue() == 1);

            Assert.Throws<InvalidOperationException>(() => queue.Peek());
            Assert.Throws<InvalidOperationException>(() => queue.Dequeue());
        }

        [Test]
        public static void Tree ()
        {
            //              10
            //      5               15
            //  2       7       12      17
            //      6               13

            Tree<int> tree = new Tree<int>
            {
                Root = new Tree<int>.Node(10)
                {
                    Left = new Tree<int>.Node(5)
                    {
                        Left = new Tree<int>.Node(2),
                        Right = new Tree<int>.Node(7)
                        {
                            Left = new Tree<int>.Node(6)
                        },
                    },
                    Right = new Tree<int>.Node(15)
                    {
                        Left = new Tree<int>.Node(12)
                        {
                            Right = new Tree<int>.Node(13)
                        },
                        Right = new Tree<int>.Node(17)
                    }
                }
            };

            Assert.That(tree.InOrder() == "2,5,6,7,10,12,13,15,17,");
            Assert.That(tree.PreOrder() == "10,5,2,7,6,15,12,13,17,");
            Assert.That(tree.PostOrder() == "2,6,7,5,13,12,17,15,10,");
        }
    }
}
