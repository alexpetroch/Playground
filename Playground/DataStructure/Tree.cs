﻿using System;
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

        public int MinDepth(Node Root)
        {
            /*
            Level Order traversal
            Maintain level.
            When find first leaf return
            */

            System.Collections.Generic.Queue<Node> queue = new System.Collections.Generic.Queue<Node>();
            System.Collections.Generic.Queue<int> levels = new System.Collections.Generic.Queue<int>();

            queue.Enqueue(Root);
            levels.Enqueue(1);

            int min = int.MaxValue;
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                int level = levels.Dequeue();

                if (node.Left == null && node.Right == null)
                {
                    return level;
                }

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                    levels.Enqueue(level + 1);
                }

                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                    levels.Enqueue(level + 1);
                }
            }

            return min;
        }

        public int MinDepth2(Node node)
        {
            /*
            Level Order traversal
            Maintain level.
            When find first leaf return
            */

            if (node == null) return 0;
            if (node.Left == null && node.Right == null) return 1;

            if (node.Left == null)
            {
                return 1 + MinDepth2(node.Right);
            }

            if (node.Right == null)
            {
                return 1 + MinDepth2(node.Left);
            }

            return 1 + Math.Min(MinDepth2(node.Left), MinDepth2(node.Right));
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

        public T LeastCommonAncestor (T value1, T value2)
        {

            /*
            Build path from node to the root
            Until find node
            Make paths equals
            Start from paths to find common point
            */

            List<T> empty = new List<T>();
            List<T> path1 = FindAndBuildPath(Root, value1, empty);
            List<T> path2 = FindAndBuildPath(Root, value2, empty);

            if (path1 == null || path2 == null)
            {
                return default(T);
            }

            if (value1.CompareTo(value2) == 0)
            {
                return value1;
            }

            int index1 = path1.Count - 1;
            int index2 = path2.Count - 1;

            while (index1 != index2)
            {
                if (index1 > index2)
                {
                    if (path1[index1].CompareTo(value2) != 0)
                    {
                        index1--;
                    }
                    else
                    {
                        return value2;
                    }
                }
                else
                {
                    if (path2[index2].CompareTo(value1) != 0)
                    {
                        index2--;
                    }
                    else
                    {
                        return value1;
                    }
                }
            }

            while (index1 >= 0 && path1[index1].CompareTo(path2[index2]) != 0)
            {
                index1--;
                index2--;
            }

            return index1 >= 0 ? path1[index1] : default(T);
        }

        public List<T> FindAndBuildPath(Node node, T value, List<T> pathSoFar)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.CompareTo(value) == 0)
            {
                return pathSoFar;
            }

            List<T> newPath = new List<T>(pathSoFar);
            newPath.Add(node.Value);

            List<T> found = FindAndBuildPath(node.Left, value, newPath);
            if (found == null)
            {
                found = FindAndBuildPath(node.Right, value, newPath);
            }

            return found;
        }

        /// <summary>
        /// Given a binary search tree T, where each node contains a positive integer, and an integer K, 
        /// you have to find whether or not there exist two different nodes A and B such that A.value + B.value = K.
        /// Return 1 to denote that two such nodes exist.Return 0, otherwise.
        /// </summary>
        public bool IsSumExist(T sum)
        {
            if (sum.CompareTo(Root.Value) == 0)
            {
                return false;
            }

            System.Collections.Generic.Stack<Node> normal = new System.Collections.Generic.Stack<Node>();
            System.Collections.Generic.Stack<Node> reverse = new System.Collections.Generic.Stack<Node>();


            // done1, val1 and curr1 are used for normal inorder traversal using s1
            // done2, val2 and curr2 are used for reverse inorder traversal using s2
            bool done1 = false, done2 = false;
            int val1 = 0, val2 = 0;
            Node curr1 = Root;
            Node curr2 = Root;

            // The loop will break when we either find a pair or one of the two
            // traversals is complete
            while (true)
            {
                // Find next node in normal Inorder traversal. See following post
                while (!done1)
                {
                    if (curr1 != null)
                    {
                        normal.Push(curr1);
                        curr1 = curr1.Left;
                    }
                    else
                    {
                        if (normal.Count == 0)
                            done1 = true;
                        else
                        {
                            curr1 = normal.Pop();
                            val1 = Convert.ToInt32(curr1.Value);
                            curr1 = curr1.Right;
                            done1 = true;
                        }
                    }
                }

                // Find next node in REVERSE Inorder traversal. 
                // The only difference between above and below loop is, in below loop
                // right subtree is traversed before left subtree
                while (!done2)
                {
                    if (curr2 != null)
                    {
                        reverse.Push(curr2);
                        curr2 = curr2.Right;
                    }
                    else
                    {
                        if (reverse.Count == 0)
                            done2 = true;
                        else
                        {
                            curr2 = reverse.Pop();
                            val2 = Convert.ToInt32(curr2.Value);
                            curr2 = curr2.Left;
                            done2 = true;
                        }
                    }
                }

                // If we find a pair, then print the pair and return. The first
                // condition makes sure that two same values are not added
                if ((val1 != val2) && (val1 + val2).CompareTo(sum) == 0)
                {
                    return true;
                }

                // If sum of current values is smaller, then move to next node in
                // normal inorder traversal
                else if ((val1 + val2).CompareTo(sum) < 0)
                    done1 = false;

                // If sum of current values is greater, then move to next node in
                // reverse inorder traversal
                else if ((val1 + val2).CompareTo(sum) > 0)
                    done2 = false;

                // If any of the inorder traversals is over, then there is no pair
                // so return false
                if (val1 >= val2)
                    return false;
            }
        }

        /// <summary>
        /// O(n2) - solution
        /// Given a binary search tree T, where each node contains a positive integer, and an integer K, 
        /// you have to find whether or not there exist two different nodes A and B such that A.value + B.value = K.
        /// Return 1 to denote that two such nodes exist.Return 0, otherwise.
        /// </summary>
        public int IsSumExistOption2(int sum)
        {

            if (sum.CompareTo(Root.Value) == 0)
            {
                return 0;
            }

            int rootValue = Convert.ToInt32(Root.Value);
            if (sum - rootValue < rootValue)
            {
                return IsSumExist(Root.Left, Root, sum) ? 1 : 0;
            }

            return IsSumExist(Root, Root.Right, sum) ? 1 : 0;
        }

        private bool IsSumExist(Node left, Node rigth, int sum)
        {
            if (left == null || rigth == null)
            {
                return false;
            }

            int curSum = Convert.ToInt32(left.Value) + Convert.ToInt32(rigth.Value);
            if (curSum == sum && left != rigth)
            {
                return true;
            }

            if (curSum < sum)
            {
                return IsSumExist(left.Right, rigth, sum) || IsSumExist(left, rigth.Right, sum);
            }

            // more than sum	
            return IsSumExist(left.Left, rigth, sum) || IsSumExist(left, rigth.Left, sum);
        }       
    }
}
