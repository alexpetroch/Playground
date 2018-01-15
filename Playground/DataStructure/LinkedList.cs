using System;

namespace Playground.DataStructure
{
    public class LinkedList<T> where T : IComparable
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

        public Node Add(Node node)
        {
            if (_head == null)
            {
                _head = new Node() { Value = node.Value };
                _tail = _head;
                return _head;
            }

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
    }
}
