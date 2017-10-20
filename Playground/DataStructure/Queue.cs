using System;

namespace Playground.DataStructure
{
    public class Queue<T>
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
}
