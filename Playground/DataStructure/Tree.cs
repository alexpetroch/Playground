using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playground.DataStructure
{
    public class Tree<T> where T : IComparable
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

        public List<T> PreOrderIterative(Node root)
        {
            if (root == null)
            {
                return null;
            }

            // Root Left Right
            System.Collections.Generic.Stack<Node> stack = new System.Collections.Generic.Stack<Node>();
            stack.Push(root);

            List<T> res = new List<T>();

            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                res.Add(node.Value);

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }

            return res;
        }

        public string PostOrder()
        {
            StringBuilder sb = new StringBuilder();
            PostOrder(_root, sb);
            return sb.ToString();
        }

        public Node InvertTree(Node node)
        {
            /*
            take left element  and set it as right element
                 right element and set it as left element

            repeat 
            */

            if (node == null)
            {
                return null;
            }

            var left = node.Left;
            var right = node.Right;

            node.Right = left;
            node.Left = right;

            InvertTree(left);
            InvertTree(right);

            return node;
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

        public List<List<T>> ZigzagLevelOrder()
        {
            /*
            have 2 stacks 
            while both are not empty.
            go through one stack and put to the other and visa varsa
            */

            System.Collections.Generic.Stack<Node> stackL = new System.Collections.Generic.Stack<Node>();
            System.Collections.Generic.Stack<Node> stackR = new System.Collections.Generic.Stack<Node>();

            stackL.Push(Root);

            List<List<T>> res = new List<List<T>>();

            while (stackL.Count > 0 || stackR.Count > 0)
            {
                List<T> level = new List<T>();
                var stackFrom = stackL.Count > 0 ? stackL : stackR;
                var stackTo = stackL.Count > 0 ? stackR : stackL;
                bool left = stackFrom == stackL;

                while (stackFrom.Count > 0)
                {
                    Node node = stackFrom.Pop();
                    level.Add(node.Value);

                    if(left)
                    {
                        if (node.Left != null)
                        {
                            stackTo.Push(node.Left);
                        }

                        if (node.Right != null)
                        {
                            stackTo.Push(node.Right);
                        }
                    }
                    else
                    {
                        if (node.Right != null)
                        {
                            stackTo.Push(node.Right);
                        }

                        if (node.Left != null)
                        {
                            stackTo.Push(node.Left);
                        }
                    }

                    
                }

                res.Add(level);
            }

            return res;
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

            if (!isSameTree(nodeA.Left, nodeB.Left))
            {
                return false;
            }

            return isSameTree(nodeA.Right, nodeB.Right);
        }

        public bool isSymmetric()
        {
            return isSymmetricTree(Root.Left, Root.Right);

        }

        public bool isSymmetricTree(Node left, Node right)
        {

            if (left == null && right == null)
            {
                return true;
            }

            if (left != null && right != null && left.Value.CompareTo(right.Value) == 0 &&
            isSymmetricTree(left.Left, right.Right) && isSymmetricTree(left.Right, right.Left))
            {
                return true;
            }

            return false;
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

        public bool HasPathSum(T sum)
        {            
            return HasPathSum(Root, Convert.ToInt32(sum));
        }

        public bool HasPathSum(Node node, int sum)
        {
            if (node == null)
            {
                return false;
            }

            if (node.Left == null && node.Right == null && node.Value.Equals(sum))
            {
                return true;
            }

            int value = Convert.ToInt32(node.Value);
            if (HasPathSum(node.Left, sum - value))
            {
                return true;
            }

            return HasPathSum(node.Right, sum - value);
        }

        public static Node SortedArrayToBST(List<T> list)
        {
            return SortedArrayToBST(list, 0, list.Count - 1);
        }

        private static Node SortedArrayToBST(List<T> list, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int middle = start + (end - start) / 2;
            Node node = new Node(list[middle]);
            node.Left = SortedArrayToBST(list, start, middle - 1);
            node.Right = SortedArrayToBST(list, middle + 1, end);
            return node;
        }

        public static Node BuildTreeFromInAndPostOrder(List<T> inOrder, List<T> postOrder)
        {            
            int postOrderIndex = postOrder.Count - 1;
            Node root = BuildTreeFromInAndPostOrder(inOrder, 0, inOrder.Count - 1, postOrder, ref postOrderIndex);
            return root;
        }

        private static Node BuildTreeFromInAndPostOrder(List<T> inOrder, int start, int end, 
            List<T> postOrder, ref int postOrderIndex)
        {

            if (start > end || postOrderIndex < 0)
            {
                return null;
            }

            Node node = new Node(postOrder[postOrderIndex]);
            postOrderIndex--;

            int rootIndex = InOrderIndex(inOrder, start, end, node.Value);
            node.Right = BuildTreeFromInAndPostOrder(inOrder, rootIndex + 1, end, postOrder, ref postOrderIndex);
            node.Left = BuildTreeFromInAndPostOrder(inOrder, start, rootIndex - 1, postOrder, ref postOrderIndex);
            return node;
        }

        private static int InOrderIndex(List<T> inorder, int start, int end, T value)
        {
            for (int i = start; i <= end; i++)
            {
                if (inorder[i].Equals(value))
                {
                    return i;
                }
            }

            return -1;
        }

        public List<List<T>> LevelOrderArrayByLevels()
        {

            System.Collections.Generic.Queue<Node> queue = new System.Collections.Generic.Queue<Node>();
            List<List<T>> res = new List<List<T>>();

            queue.Enqueue(Root);

            while (true)
            {
                if (queue.Count == 0)
                {
                    break;
                }

                int nodeCount = queue.Count;

                List<T> level = new List<T>();
                while (nodeCount > 0)
                {
                    Node node = queue.Dequeue();
                    level.Add(node.Value);
                    if (node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);
                    }

                    nodeCount--;
                }

                res.Add(level);
            }

            return res;
        }

        public Node Flatten()
        {
            /*
             1
            / \
           2   5
          / \   \
         3   4   6

         1
          \
           2
            \
             3
              \
               4
                \
                 5
                  \
                   6
           */
            var node = Root;
            while (node != null)
            {
                if (node.Left != null)
                {
                    var rightMost = node.Left;
                    while (rightMost.Right != null)
                    {
                        rightMost = rightMost.Right;
                    }

                    rightMost.Right = node.Right;
                    node.Right = node.Left;
                    node.Left = null;
                }

                node = node.Right;
            }

            return Root;
        }

        public Node ToDoubleLinedList()
        {
            ConvertToDll(Root);

            Node head = Root;
            while(head.Left != null)
            {
                head = head.Left;
            }

            return head;
        }

        private Node ConvertToDll(Node node)
        {
            if (node == null)
            {
                return node;
            }

            if (node.Left != null)
            {
                // Convert the left subtree
                Node left = ConvertToDll(node.Left);

                // take the rightmost elem
                while (left.Right != null)
                {
                    left = left.Right;
                }

                left.Right = node;
                node.Left = left;
            }

            if (node.Right != null)
            {
                // Convert the right subtree
                Node right = ConvertToDll(node.Right);

                // take the left most elem
                while (right.Left != null)
                {
                    right = right.Left;
                }

                right.Left = node;
                node.Right = right;
            }

            return node;
        }


        List<List<T>> treeTraversal = new List<List<T>>();
        Dictionary<int, List<T>> dict = new Dictionary<int, List<T>>();

        public List<List<T>> VerticalOrderTraversal()
        {
            BuildVertOrderTraversal(Root, 0);

            var list = dict.Keys.ToList();
            list.Sort();

            // Loop through keys.
            foreach (var key in list)
            {
                var vertList = dict[key];
                treeTraversal.Add(vertList);
            }

            return treeTraversal;
        }

        public void BuildVertOrderTraversal(Node node, int level)
        {
            if (node == null)
            {
                return;
            }

            // PreOrder traversal
            // do stuff here
            if (!dict.ContainsKey(level))
            {
                var newList = new List<T>();
                newList.Add(node.Value);
                dict.Add(level, newList);
            }
            else
            {
                var list = dict[level];
                list.Add(node.Value);
            }


            BuildVertOrderTraversal(node.Left, level - 1);
            BuildVertOrderTraversal(node.Right, level + 1);
        }

        public List<List<T>> VerticalOrderTraversal_Level()
        {
            /*
            Level Order traversal
            Have a queue
            Have a queue of levels and put them into hash
            Maintain the max and min value to iterate throuh resulted keys to
            generate array
 
            */

            treeTraversal.Clear();
            dict.Clear();

            System.Collections.Generic.Queue<Node> qNodes = new System.Collections.Generic.Queue<Node>();
            Queue<int> qLevels = new Queue<int>();

            qNodes.Enqueue(Root);
            qLevels.Enqueue(0);

            int min = int.MaxValue;
            int max = int.MinValue;

            while (qNodes.Count > 0)
            {
                int level = qLevels.Dequeue();
                var node = qNodes.Dequeue();

                min = Math.Min(level, min);
                max = Math.Max(level, max);

                if (dict.ContainsKey(level))
                {
                    dict[level].Add(node.Value);
                }
                else
                {
                    List<T> newList = new List<T>() { node.Value };
                    dict.Add(level, newList);
                }

                if (node.Left != null)
                {
                    qNodes.Enqueue(node.Left);
                    qLevels.Enqueue(level - 1);
                }

                if (node.Right != null)
                {
                    qNodes.Enqueue(node.Right);
                    qLevels.Enqueue(level + 1);
                }
            }

            for (int i = min; i <= max; i++)
            {
                if (dict.ContainsKey(i))
                {
                    treeTraversal.Add(dict[i]);
                }
            }

            return treeTraversal;
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

        public Node NextGreaterSuccessor(T value)
        {

            // find node
            // 1 case: has right node -> traverse until find the left most node
            // 2 case: no right node -> start from head go down until find the same node with maintainf parent

            var node = Search(value);
            if(node.Right != null)
            {
                var nodeL = node.Right;
                while (nodeL.Left != null)
                {
                    nodeL = node.Left;
                }
                return nodeL;
            }

            var nodeParent = Root;
            Node nodeSeek = null;
            while (nodeSeek != node)
            {
                if(nodeParent.Value.CompareTo(value) > 0)
                {
                    nodeSeek = nodeParent;
                    nodeParent = nodeParent.Left;
                }
                else
                {
                    nodeParent = nodeParent.Right;
                }
            }

            return nodeSeek;
            
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
