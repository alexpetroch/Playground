using Playground.DataStructure;
using System;
using System.Collections.Generic;

namespace Playground.Interview
{
    public class DynamicQ
    {
        Dictionary<string, int> _wordBreakResult = new Dictionary<string, int>();
        Dictionary<string, string> _wordBreakSpaceResult = new Dictionary<string, string>();

        List<string> ans = new List<string>();
        Dictionary<string, int> memString = new Dictionary<string, int>();
        string _sentance = string.Empty;
        
        /// <summary>
        /// https://www.interviewbit.com/problems/word-break/
        /// </summary>
        public int WordBreak(string A, List<string> B)
        {

            HashSet<string> hash = new HashSet<string>();
            for (int i = 0; i < B.Count; i++)
            {
                hash.Add(B[i]);
            }

            _wordBreakResult.Clear();
            return WordBreak(A, hash);
                
        }

        private int WordBreak(string word, HashSet<string> hash)
        {
            if (hash.Contains(word))
            {
                return 1;
            }

            if (_wordBreakResult.ContainsKey(word))
            {
                return _wordBreakResult[word];
            }

            for (int i = 0; i < word.Length; i++)
            {
                string substring = word.Substring(0, i);
                if (hash.Contains(substring))
                {
                    string rightString = word.Substring(i, word.Length - i);
                    if(WordBreak(rightString, hash) == 1)
                    {
                        _wordBreakResult.Add(word, 1);
                        return 1;
                    }
                }
            }

            _wordBreakResult.Add(word, 0);
            return 0;
        }

        public object WordBreakAddSpace(string str, List<string> dic)
        {
            HashSet<string> hash = new HashSet<string>();
            for (int i = 0; i < dic.Count; i++)
            {
                hash.Add(dic[i]);
            }

            _wordBreakSpaceResult.Clear();
            return WordBreakAddSpace(str, hash);
        }

        private string WordBreakAddSpace(string word, HashSet<string> hash)
        {
            if (hash.Contains(word))
            {
                return word;
            }

            if (_wordBreakSpaceResult.ContainsKey(word))
            {
                return _wordBreakSpaceResult[word];
            }

            for (int i = 0; i < word.Length; i++)
            {
                string substring = word.Substring(0, i);
                if (hash.Contains(substring))
                {
                    string rightString = word.Substring(i, word.Length - i);
                    string sentance = WordBreakAddSpace(rightString, hash);
                    if (sentance != null)
                    {
                        _wordBreakSpaceResult.Add(word, substring + " " + sentance);
                        return substring + " " + sentance;
                    }
                }
            }

            _wordBreakSpaceResult.Add(word, null);
            return null;
        }

        public static int ClimbStairs(int A)
        {
            int[] steps = new int[A + 1];
            int total = CountStairs(0, A, steps);

            int[] steps2 = new int[A + 1];
            int total2 = CountStairs2(A, steps2);
            return total;
        }

        private static int CountStairs(int current, int max, int[] steps)
        {
            if (current == max)
            {                
                return 1;
            }
            else if (current > max)
            {
                return 0;
            }
            else if (steps[current] != 0)
            {
                return steps[current];
            }

            steps[current] = CountStairs(current + 1, max, steps) + CountStairs(current + 2, max, steps);
            return steps[current];
        }

        private static int CountStairs2(int current, int[] steps)
        {
            if (current == 0)
            {
                return 1;
            }
            else if (current < 0)
            {
                return 0;
            }
            else if (steps[current] > -1)
            {
                return steps[current];
            }

            steps[current] = CountStairs2(current - 1, steps) + CountStairs2(current - 2, steps);
            return steps[current];
        }

        /// <summary>
        ///  Given an array of non-negative integers, you are initially positioned at the first index of the array.
        ///  Each element in the array represents your maximum jump length at that position.
        ///  Determine if you are able to reach the last index.
        /// </summary>
        public bool CanJump(List<int> array)
        {
            int currJump = 0;
            for (int i = 0; i < array.Count; i++)
            {
                if (currJump < 0) return false;

                currJump = Math.Max(array[i], currJump);
                currJump--;
            }

            return true;
        }

        public List<List<int>> memory = new List<List<int>>();

        /// <summary>
        /// Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right 
        /// which minimizes the sum of all numbers along its path
        /// You can only move either down or right at any point in time.
        /// </summary>
        public int MinPathSum(List<List<int>> A)
        {
            /*
            Input matrix: mxn - non negative
            path from top left -> bottom right with min sum

            How we can go: down or right
            Start from top left and go to the all other points with sum calc
            Iterate/Recurce the same until rich the right bottom
            */

            for (int i = 0; i < A.Count; i++)
            {
                List<int> list = new List<int>();
                for (int j = 0; j < A[i].Count; j++)
                {
                    list.Add(-1);
                }

                memory.Add(list);
            }


            return CalculateMinPath(A, A.Count - 1, A[0].Count - 1);
        }

        private int CalculateMinPath(List<List<int>> A, int row, int column)
        {
            // wrong path
            if (row < 0 || column < 0)
            {
                return int.MaxValue;
            }

            // if reach check value and return;
            if (row == 0 && column == 0)
            {
                return A[0][0];
            }

            if (memory[row][column] != -1)
            {
                return memory[row][column];
            }


            // DP[i][j] = A[i][j] + min(DP[i-1][j],DP[i][j-1]).

            memory[row][column] = A[row][column] +
            System.Math.Min(CalculateMinPath(A, row - 1, column),
                            CalculateMinPath(A, row, column - 1));
            return memory[row][column];
        }

        int[] memo;
        /// <summary>
        /// Given A, how many structurally unique BST’s (binary search trees) that store values 1...A?
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int NumUniqueBinarySearchTrees(int n)
        {
            memo = new int[n + 1];
            return CalculateTrees(n);
        }

        private int CalculateTrees(int n)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            int count = 0;
            for (int i = 1; i <= n; i++)
            {
                count += CalculateTrees(i - 1) * CalculateTrees(n - i);
            }

            memo[n] = count;
            return count;
        }

        public int MaxPathSumInTree(Tree<int>.Node root)
        {
            if (root == null)
            {
                return 0;
            }

            int max = int.MinValue;
            MaxPathSumInSubTree(root, ref max);            
            return max;
        }

        private int MaxPathSumInSubTree(Tree<int>.Node node, ref int max)
        {
            if (node == null)
            {
                return 0;
            }

            int sumLeft = MaxPathSumInSubTree(node.Left, ref max);
            int sumRight = MaxPathSumInSubTree(node.Right, ref max);

            // Max with one child node
            int maxParent = Math.Max(node.Value, node.Value + Math.Max(sumLeft, sumRight));

            // Max Top represents the sum where the node is 'considered as it would be the root' 
            int maxTop = Math.Max(maxParent, node.Value + sumLeft + sumRight);

            // Store the Maximum Result.
            max = Math.Max(max, maxTop);
            return maxParent;
        }

        /// <summary>
        /// You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed,
        /// the only constraint stopping you from robbing each of them is that adjacent houses have security system connected and 
        /// it will automatically contact the police if two adjacent houses were broken into on the same night.
        /// Given a list of non-negative integers representing the amount of money of each house, determine the maximum amount of money you can rob tonight without alerting the police.
        /// </summary>
        public static int Rob(int[] nums)
        {

            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int n = nums.Length;
            int prevNo = 0;
            int prevYes = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int temp = prevNo;
                prevNo = System.Math.Max(prevNo, prevYes);
                prevYes = nums[i] + temp;
            }

            return System.Math.Max(prevNo, prevYes);
        }
    }
}
