using System.Collections.Generic;
using System.Linq;

namespace Playground.DataStructure
{
    public class LRUCache
    {

        /*
        Get element from hash -> 
        Doubled Linked list to maintain capacity:

        If exist in hash get node and update it. put into head
           no exist -1     

        put: if exist put into head
             if not -1. move the last elelemt from list and put a new one and save in hash    

        */

        private int _capacity;
        private Dictionary<int, LinkedListNode<CacheData>> _hash;
        private System.Collections.Generic.LinkedList<CacheData> _linkedList;

        class CacheData
        {
            public CacheData(int key, int value)
            {
                Value = value;
                Key = key;
            }

            public int Value;
            public int Key;
        }

        public LRUCache(int capacity)
        {
            _capacity = capacity;
            _hash = new Dictionary<int, LinkedListNode<CacheData>>();
            _linkedList = new System.Collections.Generic.LinkedList<CacheData>();
        }

        public int Get(int key)
        {
            if (_hash.ContainsKey(key))
            {
                LinkedListNode<CacheData> node = _hash[key];
                if (node == _linkedList.First)
                {
                    return node.Value.Value;
                }

                _linkedList.Remove(node);

                // add as new head
                CacheData data = new CacheData(node.Value.Key, node.Value.Value);
                _linkedList.AddFirst(new LinkedListNode<CacheData>(data));

                _hash[key] = _linkedList.First;

                return node.Value.Value;
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            int oldValue = Get(key);
            if (oldValue == -1)
            {
                if (_linkedList.Count + 1 > _capacity)
                {
                    var tail = _linkedList.Last;
                    int removeKey = tail.Value.Key;
                    _hash.Remove(removeKey);
                    _linkedList.RemoveLast();
                }

                // add as new head
                CacheData data = new CacheData(key, value);
                _linkedList.AddFirst(new LinkedListNode<CacheData>(data));

                var head = _linkedList.First;
                _hash.Add(key, head);
            }
            // key exist but value is not the same. update key
            else
            {
                _hash[key].Value.Value = value;
            }
        }
    }

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
