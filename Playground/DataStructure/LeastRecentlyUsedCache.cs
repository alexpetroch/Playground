using System.Collections.Generic;
using System.Linq;

namespace Playground.DataStructure
{
    public class LeastRecentlyUsedCache
    {
        Dictionary<int, LinkedListNode<int>> _values = new Dictionary<int, LinkedListNode<int>>();
        System.Collections.Generic.LinkedList<int> _linkedList = new System.Collections.Generic.LinkedList<int>();
        int _capacity = 0;

        public LeastRecentlyUsedCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if(_values.ContainsKey(key))
            {
                LinkedListNode<int> node = _values[key];
                int value = node.Value;
                _linkedList.Remove(node);
                var updated = _linkedList.AddFirst(value);
                _values[key] = updated;
                return value;
            }

            return -1;
        }

        public void Set(int key, int value)
        {
            if(Get(key) != -1)
            {
                LinkedListNode<int> node = _values[key];
                node.Value = value;
            }
            else
            {
                if(_linkedList.Count + 1 > _capacity)
                {
                    var lastKey = _values.FirstOrDefault(x => x.Value.Equals(_linkedList.Last)).Key;
                    if(lastKey > 0)
                    {
                        _values.Remove(lastKey);
                    }
                    
                    _linkedList.RemoveLast();
                    
                }

                LinkedListNode<int> node = _linkedList.AddFirst(value);
                _values.Add(key, node);
            }
        }
    }   
}
