using System;

namespace Playground.DataStructure
{
    public class LinkedList<T>
    {
        public class Node
        {
            public Node Next;
            public T Value;
        }

        Node _head;
        Node _tail;

        public Node Head => _head;
        public Node Tail => _tail;

        public Node Add (T value)
        {
            if(_head == null)
            {
                _head = new Node() { Value = value };
                _tail = _head;
                return _head;
            }

            var node = new Node() { Value = value };
            _tail.Next = node;
            _tail = node;
            return node;
        }

        public void AddFirst(T value)
        {
            if (_head == null)
            {
                _head = new Node() { Value = value };
                _tail = _head;
                return;
            }

            var node = new Node() { Value = value };
            node.Next = _head;
            _head = node;
        }

        public void RemoveFirst()
        {
            if (_head == null)
            {
                throw new InvalidOperationException("No elements");
            }

            _head = _head.Next;
        }

        public void Remove(T value)
        {
            if (_tail == null)
            {
                return;
            }

            if(_head.Value.Equals(value))
            {
                if(_head.Equals(_tail))
                {
                    _tail = _tail.Next;
                }

                _head = _head.Next;
                return;
            }

            var node = _head.Next;
            var prev = _head;
            while (node != null)
            {
                if(node.Value.Equals(value))
                {                    
                    prev.Next = node.Next;

                    if(node.Equals(_tail))
                    {
                        _tail = prev;
                    }

                    break;
                }

                prev = node;
                node = node.Next;
            }
        }

        public Node Find(T value)
        {
            if (_head == null)
            {
                return null;
            }            

            var node = _head;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }

                node = node.Next;
            }

            return null;
        }

        public void Reverse()
        {
            var node = _head;
            Node prev = null;

            _tail = _head;
            while (node != null)
            {
                var next = node.Next;
                node.Next = prev;
                prev = node;
                node = next;

                if(node != null)
                {
                    _head = node;
                }
            }
        }

        public void ReverseRecursive()
        {
            var node = _head;
            _tail = _head;
             ReverseRecursive(node, null);
        }

        private Node ReverseRecursive(Node node, Node prev)
        {
            if(node == null)
            {
                _head = prev;
                return prev; 
            }

            ReverseRecursive(node.Next, node);
            node.Next = prev; 
            return prev;
        }

        public Node ReverseList(int k)
        {
            var node = Head;

            //ReverseRecursiveKElem(node.Next, node, 0, k, node);
            int current = 1;
            Node prevTail = null;
            Node currHead = Head;
            Node newHead = null; 
            while (node != null)
            {
                if(current == k)
                {
                    var nextKthNode = node.Next;
                    var it = currHead.Next;
                    var prev = currHead;
                    while (it != nextKthNode)
                    {
                        var next = it.Next;
                        it.Next = prev;
                        prev = it;
                        it = next;
                    }

                    if(prevTail != null)
                    {
                        prevTail.Next = prev;                        
                    }
                    else
                    {
                        newHead = node;
                    }

                    current = 1;
                    prevTail = currHead;
                    node = nextKthNode;
                    currHead = nextKthNode;
                    continue;
                }               

                node = node.Next;
                current++;
            }

            prevTail.Next = null;
            return newHead;
        }

        

        public Node RotateRight(int k)
        {
            if (Head == null || Head.Next == null)
            {
                return Head;
            }

            int len = GetLength(Head);
            if(k % len == 0)
            {
                return Head;
            }

            k = k % len;
            int begin = len - k;

            Node prev = null;
            Node newHead = Head;
            int temp = begin;
            while (temp-- > 0)
            {
                prev = newHead;
                newHead = newHead.Next;
            }

            var findLast = newHead;
            while (findLast.Next != null)
            {
                findLast = findLast.Next;
            }

            findLast.Next = Head;
            prev.Next = null;
            return newHead;            
        }

        private static int GetLength(Node node)
        {
            if(node == null)
            {
                return 0;
            }

            int len = 0;
            var cur = node;
            while(cur != null)
            {
                cur = cur.Next;
                len++;
            }

            return len;
        }

        public static Node GetIntersectionNode(Node a, Node b)
        {

            if (a == null || b == null)
            {
                return null;
            }

            int aLen = GetLength(a);
            int bLen = GetLength(b);

            int diff = aLen - bLen > 0 ? aLen - bLen : bLen - aLen;

            if (aLen < bLen)
            {
                Node temp = b;
                b = a;
                a = temp;
            }

            while (diff > 0)
            {
                a = a.Next;
                diff--;
            }

            while (a != null && b != null)
            {
                if (a.Value.Equals(b.Value))
                {
                    return a;
                }

                a = a.Next;
                b = b.Next;
            }

            return null;
        }       
    }
}
