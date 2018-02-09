using System.Collections.Generic;

namespace Playground.DataStructure
{
    public class TrieNode
    {
        public Dictionary<char, TrieNode> Childs;
        public bool EndWord;
        public char Key;
    }

    public class Trie
    {
        private TrieNode _root;
        public TrieNode Root
        {
            get { return _root; }
        }

        public Trie()
        {
            _root = new TrieNode();            
            _root.Childs = new Dictionary<char, TrieNode>();
        }

        public bool Find (string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            value = value.ToLowerInvariant();
            TrieNode current = _root;
            for (int i = 0; i < value.Length; i++)
            {
                if(!current.Childs.ContainsKey(value[i]))
                {
                    return false;                    
                }

                current = current.Childs[value[i]];
            }

            return current != null && current.EndWord;
        }

        public void Insert (string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            value = value.ToLowerInvariant();
            TrieNode current = _root;
            for (int i = 0; i < value.Length; i++)
            {
                if (!current.Childs.ContainsKey(value[i]))
                {
                    var node = new TrieNode();
                    node.Childs = new Dictionary<char, TrieNode>();
                    node.Key = value[i];
                    current.Childs.Add(value[i], node);                   
                }

                current = current.Childs[value[i]];
            }

            // latest symbol. Mark word as end
            current.EndWord = true;
        }
    }
}
