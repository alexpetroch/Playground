using System;
using System.Collections.Generic;

namespace Playground.DataStructure
{
    public class KeyValue<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }

    public class SimpleHashTable<K, V>
    {
        // Bucket to store values.
        private System.Collections.Generic.LinkedList<KeyValue<K, V>>[] buckets;

        public SimpleHashTable(int capacity)
        {
            buckets = new System.Collections.Generic.LinkedList<KeyValue<K, V>>[capacity];
        }

        // by default 7 elements
        public SimpleHashTable() : this(7)
        {
           
        }

        public void Add(K key, V value)
        {
            int index = FindPosition(key);

            // First entry. No collisions
            if(buckets[index] == null)
            {
                buckets[index] = new System.Collections.Generic.LinkedList<KeyValue<K, V>>();
                buckets[index].AddFirst(new KeyValue<K, V>() { Key = key, Value = value });
            }
            // handle collision
            else
            {
                // for simplicity -> do not habdle equals key
                buckets[index].AddLast(new KeyValue<K, V> { Key = key, Value = value });
            }
        }

        public bool ContainsKey(K key)
        {
            return FindNode(key) != null;
        }

        public void Remove(K key)
        {
            var node = FindNode(key);
            if (node == null)
            {
                throw new KeyNotFoundException();
            }

            var prev = node.Previous;
            var linkedList = node.List;
            // if no collision just set bucket to null
            if(prev == null)
            {
                int index = FindPosition(key);
                buckets[index] = null;
            }
            else
            {
                linkedList.Remove(node);                
            }
        }

        public V this [K key]
        {
            get
            {
                if (key == null)
                {
                    throw new ArgumentNullException();
                }

                var node = FindNode(key);
                if (node == null)
                {
                    throw new KeyNotFoundException();
                }

                return node.Value.Value;
            }
            set
            {
                var node = FindNode(key);
                if (node == null)
                {
                    throw new KeyNotFoundException();
                }

                node.Value.Value = value;
            }
        }

        private LinkedListNode<KeyValue<K,V>> FindNode(K key)
        {
            int index = FindPosition(key);
            if (buckets[index] == null)
            {
                return null;
            }

            var node = buckets[index].First;
            while (node != null)
            {
                if (node.Value.Key.Equals(key))
                {
                    return node;
                }

                node = node.Next;
            }

            return null;
        }

        private int FindPosition (K key)
        {
            // hash hast to be positive
            uint hashcode = (uint)GetHashCode(key) & 0x7FFFFFFF;
            return (int)hashcode % buckets.Length;
        }

        private int GetHashCode(K key)
        {
            return key.GetHashCode();
        }
    }
}
