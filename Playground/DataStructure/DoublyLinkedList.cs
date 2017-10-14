namespace Playground.DataStructures
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
