namespace Playground.DataStructures
{
    internal class LinkedList<T>
    {
        internal class Node
        {
            public Node Next;
            public T Value;
        }

        Node _head;
        Node _tail;

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
    }
}
