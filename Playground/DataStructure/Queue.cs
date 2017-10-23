using System;

namespace Playground.DataStructure
{
    public class Queue<T> : IQueue<T>
    {
        T[] items = new T[3];
        int head = -1;
        int tail = 0;

        public void Enqueue (T value)
        {
            if (head + 1 >= items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            items[++head] = value;
        }

        public T Dequeue()
        {
            if (tail < 0 || head < tail)
            {
                throw new InvalidOperationException("queue is empty");
            }

            return items[tail++];
        }

        public T Peek()
        {
            if (tail < 0 || head < tail)
            {
                throw new InvalidOperationException("queue is empty");
            }

            return items[tail];
        }

    }

    public class QueueL<T> : IQueue<T>
    {
        LinkedList<T> _list = new LinkedList<T>();

        public void Enqueue(T value)
        {
            _list.Add(value);
        }

        public T Dequeue()
        {
            if (_list.Head == null)
            {
                throw new InvalidOperationException("queue is empty");
            }

            T value = _list.Head.Value;
            _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_list.Head == null)
            {
                throw new InvalidOperationException("queue is empty");
            }

            return _list.Head.Value;
        }

    }

    public interface IQueue<T>
    {
        void Enqueue(T value);
        T Dequeue();
        T Peek();
    }
}
