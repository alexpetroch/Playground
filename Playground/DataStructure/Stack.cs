using System;

namespace Playground.DataStructure
{
    public class Stack<T>
    {
        T[] items = new T[3];
        int index = -1;

        public void Push(T value)
        {
            if (items.Length <= index + 1)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            items[++index] = value;
        }

        public T Pop()
        {
            if (index < 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            return items[index--];
        }

        public T Peek()
        {
            if (index < 0)
            {
                throw new InvalidOperationException("stack is empty");
            }

            return items[index];
        }

    }
}
