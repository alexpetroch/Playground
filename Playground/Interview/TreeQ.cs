using Playground.DataStructure;
using System.Collections.Generic;

namespace Playground.Interview
{
    public class TreeQ
    {
        /// <summary>
        /// Given A, generate all structurally unique BST’s (binary search trees) that store values 1...A.
        /// </summary>
        public List<Tree<int>.Node> GenUniqueBST(int number)
        {
            /*
            Iterate through all number
                Pick number. Create node as root
                Build a list of array for left and right side 
                Build tree for left
                Build tree for right 
                Merge into root

                1 2 3 4
            */

            if (number < 1)
            {
                return null;
            }

            return BuildBST(1, number);
        }

        private List<Tree<int>.Node> BuildBST(int start, int end)
        {
            List<Tree<int>.Node> res = new List<Tree<int>.Node>();

            if (start > end)
            {
                res.Add(null);
                return res;
            }

            if (start == end)
            {
                res.Add(new Tree<int>.Node(start));
                return res;
            }

            for (int i = start; i <= end; i++)
            {
                var left = BuildBST(start, i - 1);
                var right = BuildBST(i + 1, end);

                for (int k = 0; k < left.Count; k++)
                {
                    for (int j = 0; j < right.Count; j++)
                    {
                        var node = new Tree<int>.Node(i);
                        node.Left = left[k];
                        node.Right = right[j];
                        res.Add(node);
                    }
                }
            }

            return res;
        }

        public Tree<int>.Node InvertTree(Tree<int>.Node node)
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

        public List<List<int>> ZigzagLevelOrder(Tree<int>.Node Root)
        {
            /*
            have 2 stacks 
            while both are not empty.
            go through one stack and put to the other and visa varsa
            */

            System.Collections.Generic.Stack<Tree<int>.Node> stackL = new System.Collections.Generic.Stack<Tree<int>.Node>();
            System.Collections.Generic.Stack<Tree<int>.Node> stackR = new System.Collections.Generic.Stack<Tree<int>.Node>();

            stackL.Push(Root);

            List<List<int>> res = new List<List<int>>();

            while (stackL.Count > 0 || stackR.Count > 0)
            {
                List<int> level = new List<int>();
                var stackFrom = stackL.Count > 0 ? stackL : stackR;
                var stackTo = stackL.Count > 0 ? stackR : stackL;
                bool left = stackFrom == stackL;

                while (stackFrom.Count > 0)
                {
                    var node = stackFrom.Pop();
                    level.Add(node.Value);

                    if (left)
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

        public bool IsSameTree(Tree<int>.Node nodeA, Tree<int>.Node nodeB)
        {
            if (nodeA == null && nodeB == null)
            {
                return true;
            }

            if ((nodeA == null && nodeB != null) || (nodeA != null && nodeB == null))
            {
                return false;
            }

            if (nodeA.Value != nodeB.Value)
            {
                return false;
            }

            if (!IsSameTree(nodeA.Left, nodeB.Left))
            {
                return false;
            }

            return IsSameTree(nodeA.Right, nodeB.Right);
        }

        public bool isSymmetric(Tree<int>.Node Root)
        {
            return isSymmetricTree(Root.Left, Root.Right);
        }

        public bool isSymmetricTree(Tree<int>.Node left, Tree<int>.Node right)
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

        public static Tree<int>.Node SortedArrayToBST(List<int> list)
        {
            return SortedArrayToBST(list, 0, list.Count - 1);
        }

        private static Tree<int>.Node SortedArrayToBST(List<int> list, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int middle = start + (end - start) / 2;
            Tree<int>.Node node = new Tree<int>.Node(list[middle]);
            node.Left = SortedArrayToBST(list, start, middle - 1);
            node.Right = SortedArrayToBST(list, middle + 1, end);
            return node;
        }

        public bool isValidBST(Tree<int>.Node Root)
        {
            return CheckValidBST(Root, int.MinValue, int.MaxValue);
        }

        private bool CheckValidBST(Tree<int>.Node node, int min, int max)
        {
            if (node == null)
            {
                return true;
            }

            if (node.Value > min && node.Value < max &&
                CheckValidBST(node.Left, min, node.Value) &&
                CheckValidBST(node.Right, node.Value, max))
            {
                return true;
            }

            return false;
        }
    }
}
