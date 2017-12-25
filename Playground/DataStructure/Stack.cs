using System;

namespace Playground.DataStructure
{
    public class Stack<T> : IStack<T>
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

    public class StackL<T>: IStack<T> where T: IComparable
    {
        LinkedList<T> _list = new LinkedList<T>();

        public void Push(T value)
        {
            _list.AddFirst(value);
        }

        public T Pop()
        {
            if (_list.Head == null)
            {
                throw new InvalidOperationException("stack is empty");
            }

            T value = _list.Head.Value;
            _list.RemoveFirst();
            return value;
        }

        public T Peek()
        {
            if (_list.Head == null)
            {
                throw new InvalidOperationException("stack is empty");
            }

            return _list.Head.Value;
        }
    }

    public interface IStack<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
    }
}
