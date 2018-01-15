using NUnit.Framework;
using Playground.DataStructure;
using Playground.Interview;
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

            LinkedListQ<int> listQ = new LinkedListQ<int>(list);

            listQ.Reverse();

            Assert.That(listQ.Head.Value == 4);
            Assert.That(listQ.Tail.Value == 1);

            // return list back
            listQ.ReverseRecursive();
            Assert.That(listQ.Head.Value == 1);

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

            var test = tree.PreOrderIterative(tree.Root);

            Assert.That(tree.LevelOrder() == "10,5,15,2,7,12,17,6,13,");
        }

        [Test]
        public static void BST()
        {
            //              10
            //      5               15
            //  2       7       12      17
            //      6               13

            BST<int> bst = new BST<int>(int.MinValue, int.MaxValue)
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

            Assert.That(bst.isValidBST() == true);
            Assert.That(bst.MaxHeight() == 4);
            
            Assert.That(bst.InOrder() == "2,5,6,7,10,12,13,15,17,");
            Assert.That(bst.InOrderWithoutRecursive() == "2,5,6,7,10,12,13,15,17,");
            Assert.That(bst.Search(13) != null);
            Assert.That(bst.Search(100) == null);
            Assert.That(bst.SearchRecurcive(13) != null);
            Assert.That(bst.SearchRecurcive(100) == null);

            var node = bst.Insert(1);
            var node1 = bst.InsertRecurcive(3);
            bst.InsertRecurcive(20);
            bst.InsertRecurcive(25);
            Assert.That(bst.MaxHeight() == 5);

            //        4
            //      /   \ 
            //     2      5
            //  1    5            
            BST<int> notBST = new BST<int>(int.MinValue, int.MaxValue)
            {
                Root = new Tree<int>.Node(4)
                {
                    Left = new Tree<int>.Node(2)
                    {
                        Left = new Tree<int>.Node(1),
                        Right = new Tree<int>.Node(5),
                    },
                    Right = new Tree<int>.Node(5)                    
                }
            };

            Assert.That(notBST.isValidBST() == false);
        }

        [Test]
        public static void HashTable()
        {
            SimpleHashTable<string, int> simpleHash = new SimpleHashTable<string, int>();
            simpleHash.Add("hello", 1);
            simpleHash.Add("world", 2);
            simpleHash.Add("this", 3);
            simpleHash.Add("is", 4);

            Assert.That(simpleHash.ContainsKey("world") == true);
            Assert.That(simpleHash.ContainsKey("nohash") == false);

            Assert.That(simpleHash["is"] == 4);
            Assert.That(simpleHash["hello"] == 1);
            simpleHash["hello"] = 10;

            Assert.That(simpleHash["hello"] == 10);
            simpleHash.Remove("this");
            Assert.That(simpleHash.ContainsKey("this") == false);
        }

        [Test]
        public static void BinarySearch()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            Assert.That(SimpleArray.BinarySearch(array, 5) == 4);
            Assert.That(SimpleArray.BinarySearch(array, 6) == -1);
            Assert.That(SimpleArray.BinarySearch(array, 2) == 1);

            int[] array1 = { 0, 1 };
            Assert.That(SimpleArray.BinarySearch(array1, 0) == 0);
            Assert.That(SimpleArray.BinarySearch(array1, 1) == 1);

            array = new int[]{ 5, 7, 7, 8, 8, 10};
            Assert.That(SimpleArray.FindCount(array, 8) == 2);

            Assert.That(SimpleArray.Sqrt(16) == 4);
            Assert.That(SimpleArray.Sqrt(10) == 3);
            Assert.That(SimpleArray.Sqrt(1) == 1);
            Assert.That(SimpleArray.Sqrt(0) == 0);
            Assert.That(SimpleArray.Sqrt(-1) == 0);
            Assert.That(SimpleArray.Sqrt(2147483647) == 46340);
            Assert.That(SimpleArray.Sqrt(930675566) == 30506);
        }

        [Test]
        public static void LRUCache()
        {
            LeastRecentlyUsedCache cache = new LeastRecentlyUsedCache(2);
            cache.Set(1, 10);
            cache.Set(5, 12);

            Assert.That(cache.Get(5) == 12);
            Assert.That(cache.Get(1) == 10);
            Assert.That(cache.Get(10) == -1);

            cache.Set(6, 14);
            Assert.That(cache.Get(5) == -1);
        }

        [Test]
        public static void Trie()
        {
            Trie trie = new Trie();
            trie.Insert("hello");
            trie.Insert("by");
            trie.Insert("bye");

            Assert.That(trie.Find("by") == true);
            Assert.That(trie.Find("bye1") == false);
        }

        [Test]
        public static void Sort()
        {
            SimpleArray array = new SimpleArray();
            int[] quick = { 2, 4, 1, 6, 7, 5, 3 };
            array.QuickSort(quick);
            for (int i = 0; i < quick.Length; i++)
            {
                Assert.That(quick[i] == i + 1);
            }

            int[] quick1 = { 2, 4, 8, 6, 7, 5, 3, 1 };
            array.QuickSort(quick1);
            for (int i = 0; i < quick1.Length; i++)
            {
                Assert.That(quick1[i] == i + 1);
            }

            int[] merge = { 2, 4, 1, 6, 7, 5, 3 };
            array.MergeSort(merge);
            for (int i = 0; i < merge.Length; i++)
            {
                Assert.That(merge[i] == i + 1);
            }

            int[] merge1 = { 2, 4, 8, 6, 7, 5, 3, 1 };
            array.MergeSort(merge1);
            for (int i = 0; i < merge1.Length; i++)
            {
                Assert.That(merge1[i] == i + 1);
            }
        }

        [Test]
        public static void ToDoubleLinedList()
        {
            //              1
            //      2               3

            Tree<int> tree = new Tree<int>
            {
                Root = new Tree<int>.Node(1)
                {
                    Left = new Tree<int>.Node(2),
                    Right = new Tree<int>.Node(3)
                }
            };

            tree.ToDoubleLinedList();
        }
    }
}
