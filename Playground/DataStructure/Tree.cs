using System;
using System.Collections;
using System.Collections.Generic;
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

        public string InOrderWithoutRecursive()
        {
            if (Root == null)
            {
                return string.Empty;
            }

            StringBuilder sb = new StringBuilder();            
            System.Collections.Generic.Stack<Node> stack = new System.Collections.Generic.Stack<Node>();
            var node = Root;
            while (node != null)
            {
                stack.Push(node);
                node = node.Left;
            }

            while (stack.Count > 0)
            {
                node = stack.Pop();
                sb.Append(node.Value + ",");

                if (node.Right != null)
                {                   
                    var nodeToVisit = node.Right;
                    while (nodeToVisit != null)
                    {
                        stack.Push(nodeToVisit);
                        nodeToVisit = nodeToVisit.Left;
                    }                   
                }                
            }

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


        // Breath First Search
        public string LevelOrder()
        {
            StringBuilder sb = new StringBuilder();
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(_root);

            while (!queue.IsEmpty())
            {
                var node = queue.Dequeue();
                sb.Append(node.Value.ToString() + ",");

                if(node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }
            }

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

        public bool isSameTree(Node nodeA, Node nodeB)
        {
            if (nodeA == null && nodeB == null)
            {
                return true;
            }

            if ((nodeA == null && nodeB != null) || (nodeA != null && nodeB == null))
            {
                return false;
            }

            if (!nodeA.Value.Equals(nodeB.Value))
            {
                return false;
            }

            if (!isSameTree(nodeA.Left, nodeB.Right))
            {
                return false;
            }

            return isSameTree(nodeA.Right, nodeB.Right);
        }

        public int MaxHeight()
        {
            return MaxHeight(Root);
        }

        private int MaxHeight(Node node)
        {
            if(node == null)
            {
                return 0;
            }

            int lDepth = 1 + MaxHeight(node.Left);
            int rDepth = 1 + MaxHeight(node.Right);

            return lDepth > rDepth ? lDepth : rDepth;
        }

        public int isBalanced(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            bool result = true;
            GetHeight(node, ref result);
            return result ? 1 : 0;
        }

        private int GetHeight(Node node, ref bool result)
        {
            if (node == null)
            {
                return 0;
            }

            int lHeight = 1 + GetHeight(node.Left, ref result);
            int rHeight = 1 + GetHeight(node.Right, ref result);

            if (Math.Abs(lHeight - rHeight) > 1)
            {
                result = false;
            }

            return lHeight > rHeight ? lHeight : rHeight;
        }

        public bool isBalancedRecurcive(Node node)
        {
            if(node == null)
            {
                return true;
            }

            int lH = MaxHeight(node.Left);
            int rH = MaxHeight(node.Right);

            if(Math.Abs(lH - rH) < 2 && isBalancedRecurcive(node.Left) && isBalancedRecurcive(node.Right))
            {
                return true;
            }

            return false;
        }
    }

    public class BST<T> : Tree<T> where T:IComparable
    {
        private T _min;
        private T _max;
        public BST(T min, T max)
        {
            _min = min;
            _max = max;
        }

        public Node Search (T value)
        {
            var node = Root;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
                else if (value.CompareTo(node.Value) < 0)
                {
                    node = node.Left;
                }
                else
                {
                    node = node.Right;
                }
            }

            return null;
        }

        public Node SearchRecurcive(T value)
        {
            return Search(value, Root);
        }
        private Node Search(T value, Node node)
        {
            if (node == null)
            {
                return null;
            }
            else if(node.Value.Equals(value))
            {
                return node;
            }

            return Search(value, value.CompareTo(node.Value) < 0 ? node.Left : node.Right);                 
        }

        public Node Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return Root;
            }

            var node = Root;
            while (node != null)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
                else if (value.CompareTo(node.Value) < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node(value);
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node(value);
                    }
                    node = node.Right;
                }
            }

            return null;
        }

        public Node InsertRecurcive(T value)
        {
            return Insert(value, Root);           
        }
        private Node Insert(T value, Node node)
        {
            if (node == null)
            {
                return new Node(value);
            }

            if (node.Value.Equals(value))
            {
                return node;
            }
            else if (value.CompareTo(node.Value) < 0)
            {
                node.Left = Insert(value, node.Left);
            }
            else
            {
                node.Right = Insert(value, node.Right);
            }
            
            return node;
        }

        public bool isValidBST()
        {
            return CheckValidBST(Root, _min, _max);
        }

        private bool CheckValidBST(Node node, T min, T max)
        {
            if (node == null)
            {
                return true;
            }

            if (node.Value.CompareTo(min) > 0 && node.Value.CompareTo(max) < 0 &&
                CheckValidBST(node.Left, min, node.Value) &&
                CheckValidBST(node.Right, node.Value, max))
            {
                return true;
            }

            return false;
        }
    }
}
