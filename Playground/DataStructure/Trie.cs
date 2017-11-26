using System.Collections.Generic;

namespace Playground.DataStructure
{
    public class Trie
    {
        class Node
        {
            public Dictionary<char, Node> Childs;
            public bool EndWord;
            public char Key;
        }

        private Node root;

        public Trie()
        {
            root = new Node();            
            root.Childs = new Dictionary<char, Node>();
        }

        public bool Find (string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            value = value.ToLowerInvariant();
            Node current = root;
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

            Node current = root;
            for (int i = 0; i < value.Length; i++)
            {
                if (!current.Childs.ContainsKey(value[i]))
                {
                    var node = new Node();
                    node.Childs = new Dictionary<char, Node>();
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
