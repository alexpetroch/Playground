using System;

namespace Playground.DataStructure
{
    public class DoublyLinkedList<T>
    {
        public class Node
        {
            public Node Next;
            public Node Prev;
            public T Value;
        }

        Node _head = null;
        Node _tail = null;

        public Node Head => _head;

        public Node Tail => _tail;

        public Node Add(T value)
        {
            // the first element
            if (_head == null)
            {
                _head = new Node() { Value = value };
                _tail = _head;
                return _head;
            }

            var node = new Node() { Value = value };

            node.Prev = _tail;
            _tail.Next = node;
            _tail = node;

            return _tail;
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

        public void Remove (Node node)
        {            
            if(node == null)
            {
                throw new ArgumentNullException("node");
            }

            if(node == _head)
            {
                _head = node.Next;
                return;
            }

            if(node == _tail)
            {
                _tail = node.Prev;
                return;
            }


            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
        }

        public void Remove(T value)
        {
            var node = Find(value);

            if(node != null)
            {
                Remove(node);
            }
        }

        public void Reverse()
        {
            _tail = _head;

            var node = _head;
            while (node != null)
            {
                var next = node.Next;
                node.Next = node.Prev;
                node.Prev = next;

                node = next;

                if(node != null)
                {
                    _head = node;
                }               
            }
        }
    }
}
