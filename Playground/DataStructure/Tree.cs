using System.Text;

namespace Playground.DataStructure
{
    public class Tree<T>
    {
        public class Node
        {
            public Node (T value)
            {
                Value = value;
            }

            public Node Left;
            public Node Right;
            public T Value;
        }

        private Node _root;
        public Node Root
        {
            get
            {
                return _root;
            }

            set
            {
                _root = value;
            }
        }

        public string InOrder ()
        {
            StringBuilder sb = new StringBuilder();
            InOrder(_root, sb);
            return sb.ToString();
        }

        private void InOrder(Node node, StringBuilder sb)
        {
            if(node == null)
            {
                return;
            }

            InOrder(node.Left, sb);
            sb.Append(node.Value.ToString() + ",");
            InOrder(node.Right, sb);
        }

        public string PreOrder()
        {
            StringBuilder sb = new StringBuilder();
            PreOrder(_root, sb);
            return sb.ToString();
        }

        private void PreOrder(Node node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            sb.Append(node.Value.ToString() + ",");
            PreOrder(node.Left, sb);
            PreOrder(node.Right, sb);
        }

        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();
            PostOrder(_root, sb);
            return sb.ToString();
        }

        private void PostOrder(Node node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            PostOrder(node.Left, sb);
            PostOrder(node.Right, sb);
            sb.Append(node.Value.ToString() + ",");
        }
    }
}
